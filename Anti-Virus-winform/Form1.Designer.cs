namespace Anti_Virus_winform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            title = new Label();
            menualFolderScanBtn = new Button();
            menualScanFD = new FolderBrowserDialog();
            menualFileScanBtn = new Button();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            title.Location = new Point(408, 55);
            title.Name = "title";
            title.Size = new Size(417, 81);
            title.TabIndex = 0;
            title.Text = "O2 Anti-Virus";
            // 
            // menualFolderScanBtn
            // 
            menualFolderScanBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            menualFolderScanBtn.Location = new Point(65, 169);
            menualFolderScanBtn.Margin = new Padding(3, 4, 3, 4);
            menualFolderScanBtn.Name = "menualFolderScanBtn";
            menualFolderScanBtn.Size = new Size(256, 85);
            menualFolderScanBtn.TabIndex = 2;
            menualFolderScanBtn.Text = "menual folder scan";
            menualFolderScanBtn.UseVisualStyleBackColor = true;
            menualFolderScanBtn.Click += menualFolderScanBtn_Click;
            // 
            // menualFileScanBtn
            // 
            menualFileScanBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            menualFileScanBtn.Location = new Point(65, 275);
            menualFileScanBtn.Name = "menualFileScanBtn";
            menualFileScanBtn.Size = new Size(256, 85);
            menualFileScanBtn.TabIndex = 3;
            menualFileScanBtn.Text = "menual file scan";
            menualFileScanBtn.UseVisualStyleBackColor = true;
            menualFileScanBtn.Click += menualFileScanBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 739);
            Controls.Add(menualFileScanBtn);
            Controls.Add(menualFolderScanBtn);
            Controls.Add(title);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "O2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Button menualFolderScanBtn;
        private FolderBrowserDialog menualScanFD;
        private Button menualFileScanBtn;
    }
}