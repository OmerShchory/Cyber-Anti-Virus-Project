using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anti_Virus_winform
{
    internal static class AVFfiles
    {
        public static string[] readBlackList()
        {
            return File.ReadAllLines("../utils/black list.txt");
        }
    }
}
