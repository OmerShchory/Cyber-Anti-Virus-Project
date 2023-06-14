
using System.Collections.Generic;

namespace O2_AV
{
    internal class FileToScan
    {
        private string path;
        private string source;

        public FileToScan(string path, string source)
        {
            Path = path;
            Source = source;
        }

        public string Path { get => path; set => path = value; }
        public string Source { get => source; set => source = value; }

        public override bool Equals(object obj)
        {
            return obj is FileToScan scan &&
                   Path == scan.Path;
        }

        // Generated the GetHashCode function to avoid compiler warrning 
        public override int GetHashCode()
        {
            return 467214278 + EqualityComparer<string>.Default.GetHashCode(Path);
        }

        public override string ToString()
        {
            return "Path: " + this.path + " | Source: " + this.source;
        }
    }
}
