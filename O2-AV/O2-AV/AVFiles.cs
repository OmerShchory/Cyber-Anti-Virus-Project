using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2_AV
{
    internal class AVFiles
    {
        public static string[] readBlackList()
        {
            return File.ReadAllLines("./utils/black list.txt");
        }

        public static string[] readWhiteList()
        {
            return File.ReadAllLines("./utils/white list.txt");
        }

        public static string[] readViruses()
        {
            return File.ReadAllLines("./utils/viruses.txt");
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
                // Handle any exception that may occur while writing to the log file
                Console.WriteLine($"An error occurred while writing to the log file: {ex.Message}");
            }
        }
    }
}
