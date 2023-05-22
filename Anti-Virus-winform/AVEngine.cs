using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anti_Virus_winform
{
    public class AVEngine
    {
        private Queue<FileToScan> FilesToScan = new Queue<FileToScan>();
        public FileScanner fs;


        public void Start()
        {
            fs = new FileScanner();
            Thread thread = new Thread(ScannerThread);
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
                        AVFfiles.WriteLog(msg);
                        Console.WriteLine(msg);
                    }
                    else if (result[0] == "2") 
                    {
                        msg = "A safe file was scanned." + " | " + fileToScan.ToString();
                        AVFfiles.WriteLog(msg);
                        Console.WriteLine(msg);
                    }
                    else
                    {
                        msg = "An unknown file was detected" + " | " + fileToScan.ToString();
                        AVFfiles.WriteLog(msg);
                        Console.WriteLine(msg);
                    }
                }
            }
        }
    }
}
