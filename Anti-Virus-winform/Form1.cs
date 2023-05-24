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
        //private void scanCriticalFolders()
        //{
        //    string folderPath = @"C:\Users\omrir\Desktop\Git projects\Cyber-Anti-Virus-Project\Anti-Virus-winform\bin\Debug\to scan";
        //    while (true)
        //    {
        //        string[] files = Directory.GetFiles(folderPath);
        //        foreach (string file in files)
        //        {
        //            engine.QueueFileForScan(file);
        //        }
        //        Task.Delay(5000).Wait();
        //    }
        //}

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
            FolderWatcher watcher = new FolderWatcher(engine);
            watcher.watch(@"C:\Users\omrir\Desktop\stam");

            //AVFfiles.WriteLog("O2 Anti Virus Is Running");
        }

        // Event handler for initiated folder scan
        private void manualFolderScanBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    Console.WriteLine(selectedFolder);
                    
                    string[] files = Directory.GetFiles(selectedFolder, "*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        engine.QueueFileForScan(new FileToScan(file,"Initiated scan"));
                    }
                }
            }
        }

        // Event handler for initiated file scan
        private void manualFileScanBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Title = "Select file to scan";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    engine.QueueFileForScan(new FileToScan(filePath,"Initiated scan"));
                }
            }
        }

        private void printLogBtn_Click(object sender, EventArgs e)
        {
            string filePath = "../utils/log.txt";

            try
            {
                // Read the contents of the file
                string fileContent = File.ReadAllText(filePath);

                // Set the TextBox text to the file content
                displayTextBox.Text = fileContent;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur while reading the file
                MessageBox.Show("Error reading the file: " + ex.Message);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Clear the TextBox
            displayTextBox.Text = string.Empty;
        }
    }
}