using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anti_Virus_winform
{
    public class FileToScan
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

        public override string ToString()
        {
            return "Path: " + this.path + " | Source: " +this.source;
        }
    }
}
