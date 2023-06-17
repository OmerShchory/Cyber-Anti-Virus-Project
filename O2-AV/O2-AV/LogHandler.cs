using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


namespace O2_AV
{
    internal class LogHandler
    {
        private Queue<string[]> messages = new Queue<string[]>();
        private Form1 form1;
        private StreamWriter writer;
        private object writerLock = new object();

        public LogHandler(Form1 form1)
        {
            this.form1 = form1;
            string logFilePath = "./utils/log.txt";
            writer = File.AppendText(logFilePath);
        }

        public void Start()
        {
            Thread thread = new Thread(LogWriterThread);
            thread.Start();
        }

        public void QueueMessageToLog(string[] msgs)
        {
            lock (messages)
            {
                messages.Enqueue(msgs);
            }
        }

        private void LogWriterThread()
        {
            while (true)
            {
                string[] messages = null;

                lock (this.messages)
                {
                    if (this.messages.Count > 0)
                    {
                        messages = this.messages.Dequeue();
                    }
                }
                //messages[0]-log message| messages[1]-notifications message
                if (messages != null) 
                {
                    string logMessage = $"{DateTime.Now} - {messages[0]}";
                    string notificationsMessage = $"{DateTime.Now} - {messages[1]}";

                    // Lock the writerLock object to ensure only
                    // one thread will get access to the streamWriter
                    lock (writerLock)
                    {
                        writer.WriteLine(logMessage);
                        writer.Flush();
                    }
                    // Ensure that the UI will be updated
                    if (!(messages[1] == ""))
                    {
                        form1.Invoke(new Action(() =>
                        {
                            form1.WriteToDisplayTextBox(notificationsMessage 
                                + Environment.NewLine);
                        }));
                    }
                    
                }
            }
        }
    }
}
