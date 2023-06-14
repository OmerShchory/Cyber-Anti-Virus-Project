﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


namespace O2_AV
{
    internal class LogHandler
    {
        private Queue<string> messages = new Queue<string>();
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

        public void QueueMessageToLog(string notifications_msg)
        {
            lock (messages)
            {
                messages.Enqueue(notifications_msg);
            }
        }

        private void LogWriterThread()
        {
            while (true)
            {
                string message = null;

                lock (messages)
                {
                    if (messages.Count > 0)
                    {
                        message = messages.Dequeue();
                    }
                }

                if (message != null)
                {
                    string logMessage = $"{DateTime.Now} - {message}";

                    // Lock the writerLock object to ensure only one thread will
                    // get access to the streamWriter
                    lock (writerLock)
                    {
                        writer.WriteLine(logMessage);
                        writer.Flush();
                    }
                    // Ensure that the UI will be updated
                    form1.Invoke(new Action(() =>
                    {
                        form1.WriteToDisplayTextBox(logMessage + Environment.NewLine);
                    }));
                }
            }
        }
    }
}
