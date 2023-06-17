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
                // To hold what we take out of the queue
                FileToScan fileToScan = null; 
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
                    string[] msgs = {"", ""};
                    // Now, scan the file
                    if (result[0] == "1")
                    {
                        msgs[0] = "ALERT! A VIRUS WAS DETECTED - " +
                            "Black list file is detected," +
                            " this is a virus." + " | " + fileToScan.ToString();
                        msgs[1] = "ALERT! A VIRUS WAS DETECTED" + " | " + 
                            fileToScan.Path;
                        AVFiles.AppendNextDetection(msgs[0]);
                        //Further explaination
                        if (this.isExpertMode) 
                        {
                            //we want to print the detailed message in the message box
                            msgs[1] = msgs[0]; 
                        }
                        logHandler.QueueMessageToLog(msgs);
                    }
                    else if (result[0] == "2")
                    {
                        msgs[0] = "ALERT! Suspected as a VIRUS due to a " +
                            "high similarity rate." +
                            " | " + fileToScan.ToString();
                        msgs[1] = "ALERT! This file is suspected as a VIRUS." +
                            " | " + fileToScan.Path;
                        AVFiles.AppendNextDetection(msgs[0]);
                        //Further explaination
                        if (this.isExpertMode) 
                        {
                            //we want to print the detailed message in the message box
                            msgs[1] = msgs[0]; 
                        }
                        logHandler.QueueMessageToLog(msgs);
                    }
                    else if (result[0] == "3")
                    {
                        msgs[0] = "A safe file was scanned - White list file is" +
                            " detected this is not a virus." + " | " + 
                            fileToScan.ToString();
                        msgs[1] = "A safe file was scanned." + " | " + fileToScan.Path;
                        if (this.isExpertMode) //Further explaination
                        {
                            //we want to print the detailed message in the message box
                            msgs[1] = msgs[0]; 
                        }
                        logHandler.QueueMessageToLog(msgs);
                    }
                    else if (result[0] == "4")
                    {
                        msgs[0] = "ALERT! An unknown file was detected - " +
                            "The file wasn't detected in the black list, " +
                                "nor the white list, could be a virus, do not trust." + 
                                " | " + fileToScan.ToString();
                        msgs[1] = "ALERT! An unknown file was detected" + " | " + 
                            fileToScan.Path;
                        AVFiles.AppendNextDetection(msgs[0]);
                        if (this.isExpertMode) //Further explaination
                        {
                            //we want to print the detailed message in the message box
                            msgs[1] = msgs[0]; 
                        }
                        logHandler.QueueMessageToLog(msgs);
                    }
                    else
                    {
                        msgs[0] = "An error has occurred when trying to scan the file." +
                            " This could be due to low permissions to access " +
                            "the file, or file was not found." +
                                " | " + fileToScan.ToString();
                        msgs[1] = "An error has occurred when trying to scan the file." + " | " 
                            + fileToScan.Path;

                        if (this.isExpertMode) //Further explaination
                        {
                            //we want to print the detailed message in the message box
                            msgs[1] = msgs[0]; 
                        }
                        logHandler.QueueMessageToLog(msgs);
                    }
                }
            }
        }
    }
}
