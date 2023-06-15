using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace O2_AV
{
    public partial class Form1 : Form
    {
        // Engine need to be in the global namespace
        AVEngine engine;
        LogHandler logHandler;
        PortScanner portScanner;
        ProcessScanner processScanner;
        RegistryScan registryScan;
        bool isExpertMode;

        public Form1()
        {
            InitializeComponent();

            // Initialize LogHandler
            this.logHandler = new LogHandler(this);
            logHandler.Start();

            // Start the AV engine
            this.engine = new AVEngine(this.logHandler);
            engine.Start();

            // Start Port Scanner
            this.portScanner = new PortScanner(this.engine, this.logHandler);
            this.portScanner.Start();

            // Start Process Scanner
            this.processScanner = new ProcessScanner(this.engine);
            this.processScanner.Start();

            // Start registry reactive scan for programs that register for automatic start up
            this.registryScan = new RegistryScan(this.engine, this.logHandler);
            this.registryScan.Start();

            // Initialize FS watcher
            FolderWatcher watcher = new FolderWatcher(this.engine,this.logHandler);
            watcher.Watch(@"C:\Users\User\AppData");
            watcher.Watch(@"C:\Users\User\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup");
            watcher.Watch(@"C:\Program Files");
            watcher.Watch(@"C:\Program Files (x86)");
            watcher.Watch(@"C:\Users\User\Desktop");
            watcher.Watch(@"C:\Users\User\Downloads");
            watcher.Watch(@"C:\Users\User\Documents");
            watcher.Watch(@"C:\Windows");
            watcher.Watch(@"C:\Users\User\Pictures");
            watcher.Watch(@"C:\Users\User\Music");
            watcher.Watch(@"C:\Users\User\Videos");

            logHandler.QueueMessageToLog("O2-Anti-Virus has launched and started! Hurray!");
        }

        private void FolderScanBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    string[] files = Directory.GetFiles(selectedFolder, "*", SearchOption.AllDirectories);
                    this.logHandler.QueueMessageToLog("Directory initiated scan - started!");
                    foreach (string file in files)
                    {
                        engine.QueueFileForScan(new FileToScan(file, "Initiated scan"));
                    }
                    this.logHandler.QueueMessageToLog("Directory initiated scan - finished!");
                }
            }
        }

        private void FileScanBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Title = "Select file to scan";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.logHandler.QueueMessageToLog("File initiated scan - started!");
                    string filePath = openFileDialog.FileName;
                    engine.QueueFileForScan(new FileToScan(filePath, "Initiated scan"));
                }
            }
        }

        private void ShowLogBtn_Click(object sender, EventArgs e)
        {
            // Specify the path of the text file you want to open
            string filePath = @"./utils/log.txt";

            try
            {
                this.logHandler.QueueMessageToLog("User - Log file displayed");
                // Launch Notepad and open the file
                Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur
                string msg = $"An error occurred while trying to open the log file: {ex.Message}";
                logHandler.QueueMessageToLog(msg);
            }

        }

        public void ConvertMalwareFilesToHex(string malwareFolderPath, string outputFilePath)
        {
            string[] malwareFiles = Directory.GetFiles(malwareFolderPath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string malwareFile in malwareFiles)
                {
                    byte[] bytes = File.ReadAllBytes(malwareFile);
                    string hexString = BitConverter.ToString(bytes);

                    writer.WriteLine(hexString);
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            this.logHandler.QueueMessageToLog("User - notification cleared!");
            // Clear the TextBox
            displayTextBox.Text = string.Empty;
        }

        public void WriteToDisplayTextBox(string message)
        {
            displayTextBox.Text += message + '\n'; 
        }

        private void IsExpertModeChckbx_CheckedChanged(object sender, EventArgs e)
        {
            this.isExpertMode = isExpertModeChckbx.Checked;
            if (this.isExpertMode)
            {
                this.logHandler.QueueMessageToLog("Expert mode - started!");
            }
            else
            {
                this.logHandler.QueueMessageToLog("Expert mode - ended!");
            }
            // Toggle IsExpertMode in AVEngine
            this.engine.ToggleExpertMode();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // The user is trying to close the form, handle the event here

                // You can display a confirmation dialog to confirm the shutdown
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    // Cancel the form closing event
                    e.Cancel = true;
                }
                else
                {
                    logHandler.QueueMessageToLog("This anti virus program has been shut down.");

                }
            }
        }

        private void ShowDetectionsBtn_Click(object sender, EventArgs e)
        {
            // Specify the path of the text file you want to open
            string filePath = @"./utils/Past Detections.txt";

            try
            {
                this.logHandler.QueueMessageToLog("User - Log file displayed");
                // Launch Notepad and open the file
                Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur
                string msg = $"An error occurred while trying to open Past Detections file: {ex.Message}";
                logHandler.QueueMessageToLog(msg);
            }

        }
    }
}
