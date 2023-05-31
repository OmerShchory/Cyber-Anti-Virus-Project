using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xunit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace O2_AV
{
    public partial class Form1 : Form
    {
        // Engine need to be in the global namespace
        AVEngine engine;
        LogHandler logHandler;
        bool isExpertMode;

        public Form1()
        {
            InitializeComponent();

            // Initialize LogHandler
            this.logHandler = new LogHandler(this);
            logHandler.start();

            // Start the AV engine
            this.engine = new AVEngine(this.logHandler);
            engine.Start();

            // Initialize FS watcher
            FolderWatcher watcher = new FolderWatcher(engine,this.logHandler);
            watcher.watch(@"C:\Users\omrir\Desktop\stam");
        }

        private void folderScanBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    string[] files = Directory.GetFiles(selectedFolder, "*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        engine.QueueFileForScan(new FileToScan(file, "Initiated scan"));
                    }
                }
            }
        }

        private void fileScanBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Title = "Select file to scan";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    engine.QueueFileForScan(new FileToScan(filePath, "Initiated scan"));
                }
            }
        }

        private void showLogBtn_Click(object sender, EventArgs e)
        {
            //string filePath = "./utils/log.txt";

            //try
            //{
            //    // Read the contents of the file
            //    string fileContent = File.ReadAllText(filePath);

            //    // Set the TextBox text to the file content
            //    displayTextBox.Text = fileContent;
            //}
            //catch (Exception ex)
            //{
            //    // Handle any exceptions that occur while reading the file
            //    MessageBox.Show("Error reading the file: " + ex.Message);
            //}

            GetNetStatPorts();
        }

        public void ConvertMalwareFilesToHex(string malwareFolderPath, string outputFilePath)
        {
            string[] malwareFiles = Directory.GetFiles(malwareFolderPath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string malwareFile in malwareFiles)
                {
                    byte[] bytes = File.ReadAllBytes(malwareFile);
                    string hexString = BitConverter.ToString(bytes);

                    writer.WriteLine(hexString);
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Clear the TextBox
            displayTextBox.Text = string.Empty;
        }

        public void writeToDisplayTextBox(string message)
        {
            displayTextBox.Text += message + '\n'; 
        }

        private void isExpertModeChckbx_CheckedChanged(object sender, EventArgs e)
        {
            this.isExpertMode = isExpertModeChckbx.Checked;
        }

        public void GetNetStatPorts()
        {
            //var Ports = new List<NetstatPort>();

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
                    if (exitStatus != "0")
                    {
                        // Command Errored. Handle Here If Need Be
                    }

                    //Get The Rows
                    string[] rows = Regex.Split(content, "\r\n");
                    foreach (string row in rows)
                    {
                        //Split it baby
                        string[] tokens = Regex.Split(row, "\\s+");
                        if (tokens.Length > 4 && (tokens[1].Equals("UDP") || tokens[1].Equals("TCP")))
                        {
                            string localAddress = Regex.Replace(tokens[2], @"\[(.*?)\]", "1.1.1.1");

                            string protocol = localAddress.Contains("1.1.1.1") ? String.Format("{0}v6", tokens[1]) : String.Format("{0}v4", tokens[1]);
                            string openPort = localAddress.Split(':')[1];

                            int pid = tokens[1] == "UDP" ? Convert.ToInt16(tokens[4]) : Convert.ToInt16(tokens[5]);
                            string state = tokens[4];

                            string processPath = GetProcessExecutablePath(pid);

                            if (processPath != null && !(int.TryParse(state, out _)))
                            {
                                // high CPU usage
                                string processName = GetProcessName(pid);
                                //
                               
                                // Need to push the path to the engine
                                Console.WriteLine(protocol,
                                        localAddress,
                                        openPort,
                                        state,
                                        pid,
                                        processName,
                                        processPath);
                            }

                        }
                    }
                    // p.Kill();
                }

            }
            catch (Exception ex)
            {

                //Record record = new Record(logType.ERROR, ex.Message, "", "");
                //engine.printToLogFile(record);
                throw;

            }

            //return Ports;
        }

        public static string GetProcessName(int pid)
        {

            string processName;

            try
            {
                processName = Process.GetProcessById(pid).ProcessName;
            }
            catch (Exception e)
            {
                processName = "-";
            }
            return processName;
        }
        private string GetProcessExecutablePath(int processId)
        {
            try
            {
                string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
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
            catch (Win32Exception ex)
            {
                //Record record = new Record(logType.ERROR, ex.Message, "", "");
                //engine.printToLogFile(record);
                throw;
            }
            catch (Exception ex)
            {
                //Record record = new Record(logType.ERROR, ex.Message, "", "");
                //engine.printToLogFile(record);
                throw;
            }
            return null;
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to exit?", "Antivirus", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            if (res == DialogResult.OK)
            {

                Environment.Exit(Environment.ExitCode);
            }
            if (res == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
