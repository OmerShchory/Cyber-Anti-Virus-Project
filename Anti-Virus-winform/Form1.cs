using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.IO;

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

        // This function will run in a seperate thread and willl automaticly enqueue the paths
        // for the critical folders for a scan with 5 seconds delay
        private void scanCriticalFolders()
        {
            string folderPath = @"C:\Users\omrir\Desktop\Git projects\Cyber-Anti-Virus-Project\Anti-Virus-winform\bin\Debug\to scan";
            while (true)
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (string file in files)
                {
                    engine.QueueFileForScan(file);
                }
                Task.Delay(5000).Wait();
            }
        }

        public Form1()
        {
            // Initialize Form and Console window
            InitializeComponent();
            InitializeConsole();

            // Start the rngine of the AV 
            engine.Start();

            // automaticly scan critical folders
            //Thread thread = new Thread(scanCriticalFolders);
            //thread.Start();

            // Initialize FS watcher
            FolderWatcher watcher = new FolderWatcher();
            watcher.watch(@"C:\Users\USER\Desktop\stam");
        }
        
        // Event handler for initiated folder scan
        private void menualFolderScanBtn_Click(object sender, EventArgs e)
        {
            //string folderPath = @"C:\\Users\\USER\\Desktop\\Git projects\\Cyber-Anti-Virus-Project\\Anti-Virus-winform\\bin\\Debug\\to scan\";

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    Console.WriteLine(selectedFolder);
                    // Do something with the selected folder path, such as scan it for malware.
                    string[] files = Directory.GetFiles(selectedFolder);
                    foreach (string file in files)
                    {
                        engine.QueueFileForScan(file);
                    }
                }
            }
        }

        // Event handler for initiated file scan
        private void menualFileScanBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Title = "Select file to scan";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    engine.QueueFileForScan(filePath);
                }
            }
        }
    }
}