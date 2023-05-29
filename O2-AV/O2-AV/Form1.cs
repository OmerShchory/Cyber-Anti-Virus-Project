using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace O2_AV
{
    public partial class Form1 : Form
    {
        // Engine need to be in the global namespace
        AVEngine engine;
        LogHandler logHandler;
        bool isExpertMode;

        public Form1()
        {
            InitializeComponent();

            // Initialize LogHandler
            this.logHandler = new LogHandler(this);
            logHandler.start();

            // Start the AV engine
            this.engine = new AVEngine(this.logHandler);
            engine.Start();

            // Initialize FS watcher
            FolderWatcher watcher = new FolderWatcher(engine,this.logHandler);
            watcher.watch(@"C:\Users\omrir\Desktop\stam");
        }

        private void folderScanBtn_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string selectedFolder = folderDialog.SelectedPath;
                    string[] files = Directory.GetFiles(selectedFolder, "*", SearchOption.AllDirectories);
                    foreach (string file in files)
                    {
                        engine.QueueFileForScan(new FileToScan(file, "Initiated scan"));
                    }
                }
            }
        }

        private void fileScanBtn_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Title = "Select file to scan";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    engine.QueueFileForScan(new FileToScan(filePath, "Initiated scan"));
                }
            }
        }

        private void showLogBtn_Click(object sender, EventArgs e)
        {
            string filePath = "./utils/log.txt";

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

            //ConvertMalwareFilesToHex("./utils/viruses", "./utils/viruses.txt");
        }

        public void ConvertMalwareFilesToHex(string malwareFolderPath, string outputFilePath)
        {
            string[] malwareFiles = Directory.GetFiles(malwareFolderPath);

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (string malwareFile in malwareFiles)
                {
                    byte[] bytes = File.ReadAllBytes(malwareFile);
                    string hexString = BitConverter.ToString(bytes).Replace("-", "");

                    writer.WriteLine(hexString);
                }
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Clear the TextBox
            displayTextBox.Text = string.Empty;
        }

        public void writeToDisplayTextBox(string message)
        {
            displayTextBox.Text += message + Environment.NewLine; 
        }

        private void isExpertModeChckbx_CheckedChanged(object sender, EventArgs e)
        {
            this.isExpertMode = isExpertModeChckbx.Checked;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Terminate all running threads
            foreach (Form form in Application.OpenForms)
            {
                if (form != this)
                {
                    form.Invoke(new Action(form.Close)); // Close the form, which will abort its associated thread
                }
            }
        }
    }
}
