using System;
using System.IO;
using System.Windows.Forms;

namespace O2_AV
{
    internal class AVFiles
    {

        LogHandler logHandler;

        
        public static string[] ReadBlackList()
        {
            return File.ReadAllLines("./utils/black list.txt");
        }

        public static string[] ReadWhiteList()
        {
            return File.ReadAllLines("./utils/white list.txt");
        }

        public static void WriteLog(string message)
        {
            string logFilePath = "./utils/log.txt";

            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    string logMessage = $"{DateTime.Now} - {message}";
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                // An exception occurred while writing to the log file
                MessageBox.Show("An error occurred when trying to write to the log file",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
