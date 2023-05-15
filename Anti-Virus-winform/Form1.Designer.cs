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
            manualFolderScanBtn = new Button();
            manualFileScanBtn = new Button();
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
            // manualFolderScanBtn
            // 
            manualFolderScanBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            manualFolderScanBtn.Location = new Point(65, 169);
            manualFolderScanBtn.Margin = new Padding(3, 4, 3, 4);
            manualFolderScanBtn.Name = "manualFolderScanBtn";
            manualFolderScanBtn.Size = new Size(256, 85);
            manualFolderScanBtn.TabIndex = 2;
            manualFolderScanBtn.Text = "manual folder scan";
            manualFolderScanBtn.UseVisualStyleBackColor = true;
            manualFolderScanBtn.Click += manualFolderScanBtn_Click;
            // 
            // manualFileScanBtn
            // 
            manualFileScanBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            manualFileScanBtn.Location = new Point(65, 275);
            manualFileScanBtn.Name = "manualFileScanBtn";
            manualFileScanBtn.Size = new Size(256, 85);
            manualFileScanBtn.TabIndex = 3;
            manualFileScanBtn.Text = "manual file scan";
            manualFileScanBtn.UseVisualStyleBackColor = true;
            manualFileScanBtn.Click += manualFileScanBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 739);
            Controls.Add(manualFileScanBtn);
            Controls.Add(manualFolderScanBtn);
            Controls.Add(title);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "O2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Button manualFolderScanBtn;
        private Button manualFileScanBtn;
    }
}