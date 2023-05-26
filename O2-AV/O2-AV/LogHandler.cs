using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace O2_AV
{
    internal class LogHandler
    {
        Queue<string> messages = new Queue<string>();
        Form1 form1;

        public LogHandler(Form1 form1)
        {
            this.form1 = form1;
        }

        public void start()
        {
            Thread thread = new Thread(logWritterThread);
            thread.Start();
        }

        public void queueMessageToLog(string message)
        {
            lock(messages)
            {
                messages.Enqueue(message);  
            }
        }

        public void logWritterThread() 
        {
            string logFilePath = "./utils/log.txt";
            // Open stream writer on the log file and run an infinite loop
            // to ensure no other process can get access to the file
            using (StreamWriter writer = File.AppendText(logFilePath))
            {
                while (true)
                {
                    try
                    {
                        string message;
                        lock (messages)
                        {
                            message = messages.Dequeue();
                            if (message != null)
                            {
                                string logMessage = $"{DateTime.Now} - {message}";
                                // Write to log file
                                writer.WriteLine(logMessage);
                                // Write to the AV text box
                                form1.writeToDisplayTextBox(logMessage + Environment.NewLine);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nothing in the queue
                    }
                }
            }
            
        }
    }
}
