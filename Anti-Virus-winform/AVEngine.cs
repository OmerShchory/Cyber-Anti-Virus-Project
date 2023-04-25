using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anti_Virus_winform
{
    internal class AVEngine
    {
        private Queue<string> FilesToScan = new Queue<string>();
        public Queue<string> BadFiles = new Queue<string>();

        public void Start()
        {
            Thread thread = new Thread(ScannerThread);
            thread.Start();

        }

        public void QueueFileForScan(string filename)
        {
            lock (FilesToScan)
            {
                FilesToScan.Enqueue(filename);
            }
        }

        private void ScannerThread()
        {
            while (true) // Scanner thread loops until the program exits
            {
                string fileToScan = null; // To hold what we take out of the queue
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
                    // Now, scan the file
                    if (FileScanner.Scan(fileToScan))
                    {
                        /*lock(BadFiles)
                        {
                            BadFiles.Enqueue(fileToScan);
                        }*/
                        Console.WriteLine("A VIRUS WAS DETECTED");
                    }
                    else
                    {
                        Console.WriteLine("A safe file was scanned.");
                    }
                }
            }
        }
    }
}
