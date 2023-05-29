using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2_AV
{
    internal class FileScanner
    {
        //private static byte[] VIRUS_FILE = { 0x36, 0x1f, 0xad, 0xf1, 0xc7, 0x12, 0xe8, 0x12, 0xd1, 0x98, 0xc4, 0xca, 0xb5, 0x71, 0x2a, 0x79 };
        List<byte[]> blackList;
        List<byte[]> whiteList;

        public FileScanner()
        {
            this.blackList = readFromFileToList(AVFiles.readBlackList());
            this.whiteList = readFromFileToList(AVFiles.readWhiteList());
        }

        public static byte[] ConvertHexStringToByteArray(string hexString)
        {
            byte[] byteArray = new byte[hexString.Length / 2];

            for (int i = 0; i < hexString.Length; i += 2)
            {
                string byteString = hexString.Substring(i, 2);
                byteArray[i / 2] = Convert.ToByte(byteString, 16);
            }

            return byteArray;
        }

        //private static string[] lines = readBlackList();

        /// <summary>
        /// Returns true if the file is a virus
        /// 
        /// </summary>
        /// <param name="filename">File to scan</param>
        /// <returns></returns>
        public string[] Scan(string filename)
        {
            byte[] file_bytes = File.ReadAllBytes(filename);

            byte[] hash;
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                md5.TransformFinalBlock(file_bytes, 0, file_bytes.Length);
                hash = md5.Hash;
            }

            string[] res = { "", filename };
            // Compare file to Black List and return true if found a match match
            for (int i = 0; i < blackList.Count(); i++)
            {
                if (CompareBytes(hash, this.blackList[i]))
                {
                    // REturn 1 if the file is detected as a virus
                    res[0] = "1";
                    return res;
                }
            }

            string[] viruses = Directory.GetFiles("./utils/viruses");
            double similarityRes = 0;
            for (int i = 0; i < viruses.Count(); i++)
            {
                similarityRes = Convert.ToDouble(runPythonScript("./utils/similarity.py", filename, viruses[i]));
                if (similarityRes*100 >= 10)
                {
                    res[0] = "2";
                    return res;
                }
            }

            for (int i = 0; i < this.whiteList.Count(); i++)
            {
                if (CompareBytes(hash, this.whiteList[i]))
                {
                    // Return 2 if the file is detected as known non virus
                    res[0] = "3";
                    return res;
                }
            }

            // Return 3 if the file is unknown
            res[0] = "4";
            return res;
        }

        private static bool CompareBytes(byte[] lhs, byte[] rhs)
        {
            if (lhs.Length != rhs.Length)
            {
                return false;
            }

            for (int i = 0; i < lhs.Length; ++i)
            {
                if (lhs[i] != rhs[i])
                {
                    return false;
                }
            }

            return true;
        }

        // Read the Black List from file and store it for comparisons
        private static List<byte[]> readFromFileToList(string[] byteArrayFromFile)
        {
            List<byte[]> listToReturn = new List<byte[]>();
            for (int i = 0; i < byteArrayFromFile.Length; i++)
            {
                listToReturn.Add(ConvertHexStringToByteArray(byteArrayFromFile[i]));
                //blackList.Add(lines[i].Split(",").Select(b => byte.Parse(b)).ToArray());
            }
            return listToReturn;
        }

        public static string runPythonScript(string pythonScript, string file1, string file2)
        {
            //byte[] bytes1 = File.ReadAllBytes(file1);
            //byte[] bytes2 = File.ReadAllBytes(file2);

            //int matches = 0;
            //for (int i = 0; i < bytes1.Length - 50; i += 50)
            //{
            //    byte[] subArray = new byte[50];
            //    Array.Copy(bytes1, i, subArray, 0, 50);
            //    if (Array.IndexOf(bytes2, subArray) != -1)
            //    {
            //        matches++;
            //    }
            //}

            //double similarity = (double)matches / (bytes1.Length / 50);
            //return similarity;
            // 1) create process info 

            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\\Users\\omrir\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe";

            // 2) Provide script and arguments
            psi.Arguments = $"\"{pythonScript}\" \"{file1}\" \"{file2}\"";

            // 3) Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // 4) Execute process and get output
            var errors = "";
            var results = "";
            using (var process = Process.Start(psi)) 
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            if (errors != null) 
            {
                return results;
            }

            return errors;
        }
    }
}
