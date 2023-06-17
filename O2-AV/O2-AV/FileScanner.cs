using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace O2_AV
{
    internal class FileScanner
    {
        List<byte[]> blackList;
        List<byte[]> whiteList;

        public FileScanner()
        {
            this.blackList = ReadFromFileToList(AVFiles.ReadBlackList());
            this.whiteList = ReadFromFileToList(AVFiles.ReadWhiteList());
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

        public string[] Scan(string filename)
        {
            string[] res = { "", filename };
            try
            {
                byte[] file_bytes = File.ReadAllBytes(filename);

                byte[] hash;
                using (var md5 = System.Security.Cryptography.MD5.Create())
                {
                    md5.TransformFinalBlock(file_bytes, 0, file_bytes.Length);
                    hash = md5.Hash;
                }

                
                // Compare file to Black List and return true if found a match match
                for (int i = 0; i < blackList.Count(); i++)
                {
                    if (CompareBytes(hash, this.blackList[i]))
                    {
                        // Return 1 if the file is detected as a virus
                        res[0] = "1";
                        return res;
                    }
                }

                for (int i = 0; i < this.whiteList.Count(); i++)
                {
                    if (CompareBytes(hash, this.whiteList[i]))
                    {
                        // Return 3 if the file is detected as non virus
                        res[0] = "3";
                        return res;
                    }
                }


                string[] viruses = Directory.GetFiles("./utils/viruses");
                double similarityRes = 0;
                for (int i = 0; i < viruses.Count(); i++)
                {
                    similarityRes = Convert.ToDouble(RunPythonScript
                        ("./utils/similarity.py", filename, viruses[i]));
                    if (similarityRes * 100 >= 60)
                    {
                        res[0] = "2";
                        return res;
                    }
                }
               
                // Return 3 if the file is unknown
                res[0] = "4";
                return res;
            }
            catch (Exception e)
            {
                res[0] = "5";
                return res;
            }
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
        private static List<byte[]> 
            ReadFromFileToList(string[] byteArrayFromFile)
        {
            List<byte[]> listToReturn = new List<byte[]>();
            for (int i = 0; i < byteArrayFromFile.Length; i++)
            {
                listToReturn.Add(ConvertHexStringToByteArray(byteArrayFromFile[i]));
            }
            return listToReturn;
        }

        public static string RunPythonScript(string pythonScript, string file1, string file2)
        {
            var psi = new ProcessStartInfo();
       
            //psi.FileName = @"C:\Users\user1\AppData\Local\Microsoft\WindowsApps\python.exe";
            psi.FileName = @"C:\\Users\\User\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe";
            //psi.FileName = @"C:\\Users\\omrir\\AppData\\Local\\Microsoft\\WindowsApps\\python.exe";

            // Provide script and arguments
            psi.Arguments = $"\"{pythonScript}\" \"{file1}\" \"{file2}\"";

            // Process configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // Execute process and get output
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
