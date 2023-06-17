using System;
using System.Threading;
using Microsoft.Win32;

namespace O2_AV
{
    class RegistryScan
    {
        private bool scanningActive;
        LogHandler LogHandler;
        AVEngine engine;

        public RegistryScan(AVEngine engine, LogHandler logHandler)
        {
            this.engine = engine;
            this.LogHandler = logHandler;
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
                RegistryReactiveScan();
                Thread.Sleep(30000);
            }
        }

        private void RegistryReactiveScan()
        {
            try
            {
                string keyPath = 
                    @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                // Open the registry key that contains the startup programs
                using(RegistryKey key = 
                Registry.CurrentUser.OpenSubKey(keyPath, false))
                {
                    if (key != null)
                    {
                        //Get the list of value names (program names)
                        //under the startup registry key
                        string[] valueNames = key.GetValueNames();

                        foreach (string valueName in valueNames)
                        {
                            string programPath = key.GetValue(valueName)?.ToString();
                            this.engine.QueueFileForScan
                                (new FileToScan(programPath, "Reactive registry scan"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during registry scanning
                string logMsg = $"An error occurred during registry scan: " +
                    $"{ex.Message}";
                string[] logMsgs = { logMsg, logMsg };
                this.LogHandler.QueueMessageToLog(logMsgs);
            }
        }
    }
}
