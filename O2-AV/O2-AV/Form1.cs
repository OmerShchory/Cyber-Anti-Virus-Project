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

namespace O2_AV
{
    public partial class Form1 : Form
    {
        // Engine need to be in the global namespace
        AVEngine engine = new AVEngine();

        public Form1()
        {
            InitializeComponent();
            
            // Start the AV engine
            engine.Start(this);

            // Initialize FS watcher
            FolderWatcher watcher = new FolderWatcher(engine,this);
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
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            // Clear the TextBox
            displayTextBox.Text = string.Empty;
        }

        public void writeToDisplayTextBox(string message)
        {
            displayTextBox.Text += message + '\n'; 
        }
    }
}
