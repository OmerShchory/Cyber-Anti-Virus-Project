using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anti_Virus_winform
{
    public class FileScanner
    {
        //private static byte[] VIRUS_FILE = { 0x36, 0x1f, 0xad, 0xf1, 0xc7, 0x12, 0xe8, 0x12, 0xd1, 0x98, 0xc4, 0xca, 0xb5, 0x71, 0x2a, 0x79 };
        List<byte[]> blackList;
        List<byte[]> whiteList;

        public FileScanner()
        { 
            this.blackList = readFromFileToList(AVFfiles.readBlackList());
            this.whiteList = readFromFileToList(AVFfiles.readWhiteList());    
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
        public bool Scan(string filename)
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
                    return true;
                }
            }
            return false;
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
        private static List<byte[]> readFromFileToList(string[] byteAttayFromFile)
        {
            List<byte[]> listToReturn = new List<byte[]>();    
            for (int i = 0; i < byteAttayFromFile.Length ; i++)
            {
                listToReturn.Add(ConvertHexStringToByteArray(byteAttayFromFile[i]));
                //blackList.Add(lines[i].Split(",").Select(b => byte.Parse(b)).ToArray());
            }
            return listToReturn;
        }


    }
}
