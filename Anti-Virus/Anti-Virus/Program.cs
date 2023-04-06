using System;

namespace Anti_Virus
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFilePath = ".\\text.txt";
            //byte[] fileContent = System.IO.File.ReadAllBytes(sourceFilePath);
            string destinationFilePath = ".\\WhiteList.txt";
            Hash_to_file(sourceFilePath, destinationFilePath); //white list
        }
        
        //function gets a file path to hash the file and write it to a destination file 
        //(can be white list or black list)
        public static void Hash_to_file(string file_path, string destination_path)
        {
            byte[] file_bytes = System.IO.File.ReadAllBytes(file_path);
            byte[] hash;

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                md5.TransformFinalBlock(file_bytes, 0, file_bytes.Length);
                hash = md5.Hash;

            }
            System.IO.File.WriteAllBytes(destination_path, hash);

        }
    }
}
