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
            menualScanBtn = new Button();
            menualScanFD = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            title.Location = new Point(357, 41);
            title.Name = "title";
            title.Size = new Size(335, 65);
            title.TabIndex = 0;
            title.Text = "O2 Anti-Virus";
            // 
            // menualScanBtn
            // 
            menualScanBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            menualScanBtn.Location = new Point(75, 199);
            menualScanBtn.Name = "menualScanBtn";
            menualScanBtn.Size = new Size(170, 64);
            menualScanBtn.TabIndex = 2;
            menualScanBtn.Text = "menual scan";
            menualScanBtn.UseVisualStyleBackColor = true;
            menualScanBtn.Click += menualScanBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 554);
            Controls.Add(menualScanBtn);
            Controls.Add(title);
            Name = "Form1";
            Text = "O2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Button menualScanBtn;
        private FolderBrowserDialog menualScanFD;
    }
}