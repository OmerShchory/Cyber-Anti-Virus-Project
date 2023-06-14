using System;
using System.Collections.Generic;
using System.Threading;

namespace O2_AV
{
    internal class AVEngine
    {
        private Queue<FileToScan> FilesToScan = new Queue<FileToScan>();
        public FileScanner fs;
        private LogHandler logHandler;
        bool isExpertMode;

        public AVEngine(LogHandler logHandler)
        {
            this.fs = new FileScanner();
            this.logHandler = logHandler;
            this.isExpertMode = false;
        }

        public void ToggleExpertMode()
        {
            this.isExpertMode = !this.isExpertMode;
        }

        public void Start()
        {
            Thread thread = new Thread(ScannerThread);
            //_displayTextBox = Form1.DisplayTextBox;
            thread.Start();
        }

        public void QueueFileForScan(FileToScan file)
        {
            lock (FilesToScan)
            {
                // Check if the file already exists in the queue
                bool exists = FilesToScan.Contains(file);

                // If the file doesn't exist, enqueue it
                if (!exists)
                {
                    FilesToScan.Enqueue(file);
                }
            }
        }

        private void ScannerThread()
        {
            while (true) // Scanner thread loops until the program exits
            {
                FileToScan fileToScan = null; // To hold what we take out of the queue
                lock (FilesToScan)
                {
                    try
                    {
                        fileToScan = FilesToScan.Dequeue();
                    }
                    catch (Exception ex)
                    {
                        // Nothing in the queue
                    }
                }

                if (fileToScan != null)
                {
                    string[] result = fs.Scan(fileToScan.Path);
                    string msg;
                    // Now, scan the file
                    if (result[0] == "1")
                    {
                        msg = "ALERT! A VIRUS WAS DETECTED" + " | " + fileToScan.ToString();
                        logHandler.QueueMessageToLog(msg);
                    }
                    else if (result[0] == "2")
                    {
                        msg = "ALERT! Suspected as a VIRUS due to a high similarity rate" + " | " + fileToScan.ToString();
                        logHandler.QueueMessageToLog(msg);
                    }
                    else if (result[0] == "3")
                    {
                        msg = "A safe file was scanned." + " | " + fileToScan.ToString();
                        logHandler.QueueMessageToLog(msg);
                    }
                    else if (result[0] == "4")
                    {
                        msg = "ALERT! An unknown file was detected" + " | " + fileToScan.ToString();
                        logHandler.QueueMessageToLog(msg);
                    }
                    else
                    {
                        msg = "An error has occurred when trying to scan the file." + " | " + fileToScan.ToString();
                        logHandler.QueueMessageToLog(msg);
                    }
                }
            }
        }
    }
}
