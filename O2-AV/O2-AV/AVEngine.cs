using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2_AV
{
    internal class AVEngine
    {
        private Queue<FileToScan> FilesToScan = new Queue<FileToScan>();
        public FileScanner fs;
        private LogHandler logHandler;
        //private TextBox _displayTextBox;

        public AVEngine(LogHandler logHandler)
        {
            this.fs = new FileScanner();
            this.logHandler = logHandler;
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
                FilesToScan.Enqueue(file);
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
                        msg = "A VIRUS WAS DETECTED" + " | " + fileToScan.ToString();
                        logHandler.queueMessageToLog(msg);
                    }
                    else if (result[0] == "2")
                    {
                        msg = "Suspected as a VIRUS due to a high similarity rate" + " | " + fileToScan.ToString();
                        logHandler.queueMessageToLog(msg);
                    }
                    else if (result[0] == "3")
                    {
                        msg = "A safe file was scanned." + " | " + fileToScan.ToString();
                        logHandler.queueMessageToLog(msg);
                    }
                    else
                    {
                        msg = "An unknown file was detected" + " | " + fileToScan.ToString();
                        logHandler.queueMessageToLog(msg);
                    }
                }
            }
        }
    }
}
