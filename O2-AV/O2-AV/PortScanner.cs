using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;

namespace O2_AV
{
    internal class PortScanner
    {
        private bool scanningActive;
        private AVEngine engine;
        LogHandler logHandler;

        public PortScanner(AVEngine engine, LogHandler logHandler) 
        {
            this.engine = engine;
            this.logHandler = logHandler;
        }

        public void Start()
        {
            scanningActive = true;
            Thread thread = new Thread(ScanLoop);
            thread.Start();
        }

        private void ScanLoop()
        {
            while (scanningActive)
            {
                GetNetStatPorts();
                Thread.Sleep(15000);
            }
        }

        public void GetNetStatPorts()
        {
            Process p = null;

            try
            {
                using (p = new Process())
                {
                    ProcessStartInfo ps = new ProcessStartInfo();
                    ps.Arguments = "-a -n -o";
                    ps.FileName = "netstat.exe";
                    ps.UseShellExecute = false;
                    ps.CreateNoWindow = true;
                    ps.WindowStyle = ProcessWindowStyle.Hidden;
                    ps.RedirectStandardInput = true;
                    ps.RedirectStandardOutput = true;
                    ps.RedirectStandardError = true;
                    p.StartInfo = ps;
                    p.Start();
                    StreamReader stdOutput = p.StandardOutput;
                    StreamReader stdError = p.StandardError;
                    string content = stdOutput.ReadToEnd() + stdError.ReadToEnd();
                    string exitStatus = p.ExitCode.ToString();

                    //Get The Rows
                    string[] rows = Regex.Split(content, "\r\n");
                    foreach (string row in rows)
                    {
                        
                        string[] tokens = Regex.Split(row, "\\s+");
                        if (tokens.Length > 4 && (tokens[1].Equals("UDP") || 
                            tokens[1].Equals("TCP")))
                        {
                            string localAddress = Regex.Replace(tokens[2],
                                @"\[(.*?)\]", "1.1.1.1");

                            string protocol = localAddress.Contains("1.1.1.1") ? 
                                String.Format("{0}v6", tokens[1]) : String.Format("{0}v4", tokens[1]);
                            string openPort = localAddress.Split(':')[1];

                            int pid = tokens[1] == "UDP" ? Convert.ToInt16(tokens[4]) : 
                                Convert.ToInt16(tokens[5]);
                            string state = tokens[4];

                            string processPath = GetProcessExecutablePath(pid);

                            if (processPath != null && !(int.TryParse(state, out _)))
                            {
                                // high CPU usage
                                string processName = GetProcessName(pid);
                                
                                PortToScan pts = new PortToScan(protocol, localAddress, 
                                    openPort, state, pid, processName, processPath);                                
                                // Pushing the the engine
                                this.engine.QueueFileForScan(new FileToScan(processPath, 
                                    "Port Reactive Scan | " + pts.ToString()));  
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string logMsg = $"An error occurred during registry scan: {ex.Message}";
                string[] logMsgs = { logMsg, logMsg };
                this.logHandler.QueueMessageToLog(logMsgs);
                throw;
            }
        }

        public string GetProcessName(int pid)
        {
            string processName;

            try
            {
                processName = Process.GetProcessById(pid).ProcessName;
            }
            catch (Exception e)
            {
                processName = "-";
                string logMsg = $"An error occurred during registry scan: {e.Message}";
                string[] logMsgs = { logMsg, logMsg };
                this.logHandler.QueueMessageToLog(logMsgs);
            }
            return processName;
        }

        private string GetProcessExecutablePath(int processId)
        {
            try
            {
                string wmiQueryString = "SELECT ProcessId, ExecutablePath " +
                    "FROM Win32_Process WHERE ProcessId = " + processId;
                using (var searcher = new ManagementObjectSearcher(wmiQueryString))
                {
                    using (var results = searcher.Get())
                    {
                        ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                        if (mo != null)
                        {
                            return (string)mo["ExecutablePath"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string logMsg = $"An error occurred during registry scan: {ex.Message}";
                string[] logMsgs = { logMsg, logMsg };
                this.logHandler.QueueMessageToLog(logMsgs);
                throw;
            }
            return null;
        }
    }
}
