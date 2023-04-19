using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Anti_Virus_winform
{
    public partial class Form1 : Form
    {
        // ===== necessary for console =====
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern void SetStdHandle(int nStdHandle, IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int GetConsoleOutputCP();

        private void InitializeConsole()
        {
            AllocConsole();

            IntPtr stdHandle = GetStdHandle(-11); // -11 is the STD_OUTPUT_HANDLE constant
            SafeFileHandle safeFileHandle = new SafeFileHandle(stdHandle, true);
            FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write);
            StreamWriter standardOutput = new StreamWriter(fileStream, System.Text.Encoding.UTF8);
            standardOutput.AutoFlush = true;

            Console.SetOut(standardOutput);
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }
        // =====

        AVEngine engine = new AVEngine();

        public Form1()
        {
            InitializeComponent();
            InitializeConsole();
            engine.Start();
        }

        private void menualScanBtn_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\\Users\\USER\\Desktop\\Git projects\\Cyber-Anti-Virus-Project\\Anti-Virus-winform\\bin\\Debug\\to scan\";
            string[] files = Directory.GetFiles(folderPath);
            foreach (string file in files)
            {
                engine.QueueFileForScan(file); 
            }
        }
    }
}