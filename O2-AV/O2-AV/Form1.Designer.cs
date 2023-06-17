namespace O2_AV
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerLbl = new System.Windows.Forms.Label();
            this.folderScanBtn = new System.Windows.Forms.Button();
            this.fileScanBtn = new System.Windows.Forms.Button();
            this.showLogBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.displayTextBox = new System.Windows.Forms.TextBox();
            this.isExpertModeChckbx = new System.Windows.Forms.CheckBox();
            this.ShowDetectionsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLbl
            // 
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Mongolian Baiti", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLbl.Location = new System.Drawing.Point(507, 57);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(504, 85);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "O2 Anti Virus";
            this.headerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // folderScanBtn
            // 
            this.folderScanBtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.folderScanBtn.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderScanBtn.Location = new System.Drawing.Point(36, 55);
            this.folderScanBtn.Name = "folderScanBtn";
            this.folderScanBtn.Size = new System.Drawing.Size(320, 123);
            this.folderScanBtn.TabIndex = 1;
            this.folderScanBtn.Text = "Scan a folder";
            this.folderScanBtn.UseVisualStyleBackColor = false;
            this.folderScanBtn.Click += new System.EventHandler(this.FolderScanBtn_Click);
            // 
            // fileScanBtn
            // 
            this.fileScanBtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.fileScanBtn.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileScanBtn.Location = new System.Drawing.Point(36, 192);
            this.fileScanBtn.Name = "fileScanBtn";
            this.fileScanBtn.Size = new System.Drawing.Size(320, 123);
            this.fileScanBtn.TabIndex = 2;
            this.fileScanBtn.Text = "Scan a file";
            this.fileScanBtn.UseVisualStyleBackColor = false;
            this.fileScanBtn.Click += new System.EventHandler(this.FileScanBtn_Click);
            // 
            // showLogBtn
            // 
            this.showLogBtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.showLogBtn.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showLogBtn.Location = new System.Drawing.Point(36, 489);
            this.showLogBtn.Name = "showLogBtn";
            this.showLogBtn.Size = new System.Drawing.Size(320, 123);
            this.showLogBtn.TabIndex = 3;
            this.showLogBtn.Text = "Show log";
            this.showLogBtn.UseVisualStyleBackColor = false;
            this.showLogBtn.Click += new System.EventHandler(this.ShowLogBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.clearBtn.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.Location = new System.Drawing.Point(36, 640);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(320, 123);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(382, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 38);
            this.label1.TabIndex = 5;
            this.label1.Text = "Notifications:";
            // 
            // displayTextBox
            // 
            this.displayTextBox.ForeColor = System.Drawing.Color.Black;
            this.displayTextBox.Location = new System.Drawing.Point(390, 254);
            this.displayTextBox.Multiline = true;
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.displayTextBox.Size = new System.Drawing.Size(1339, 507);
            this.displayTextBox.TabIndex = 6;
            // 
            // isExpertModeChckbx
            // 
            this.isExpertModeChckbx.AutoSize = true;
            this.isExpertModeChckbx.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isExpertModeChckbx.Location = new System.Drawing.Point(1518, 192);
            this.isExpertModeChckbx.Name = "isExpertModeChckbx";
            this.isExpertModeChckbx.Size = new System.Drawing.Size(225, 42);
            this.isExpertModeChckbx.TabIndex = 7;
            this.isExpertModeChckbx.Text = "Expert Mode";
            this.isExpertModeChckbx.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.isExpertModeChckbx.UseVisualStyleBackColor = true;
            this.isExpertModeChckbx.CheckedChanged += new System.EventHandler(this.IsExpertModeChckbx_CheckedChanged);
            // 
            // ShowDetectionsBtn
            // 
            this.ShowDetectionsBtn.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ShowDetectionsBtn.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowDetectionsBtn.Location = new System.Drawing.Point(36, 335);
            this.ShowDetectionsBtn.Name = "ShowDetectionsBtn";
            this.ShowDetectionsBtn.Size = new System.Drawing.Size(320, 123);
            this.ShowDetectionsBtn.TabIndex = 8;
            this.ShowDetectionsBtn.Text = "Show Past Detections";
            this.ShowDetectionsBtn.UseVisualStyleBackColor = false;
            this.ShowDetectionsBtn.Click += new System.EventHandler(this.ShowDetectionsBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1803, 843);
            this.Controls.Add(this.ShowDetectionsBtn);
            this.Controls.Add(this.isExpertModeChckbx);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.showLogBtn);
            this.Controls.Add(this.fileScanBtn);
            this.Controls.Add(this.folderScanBtn);
            this.Controls.Add(this.headerLbl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLbl;
        private System.Windows.Forms.Button folderScanBtn;
        private System.Windows.Forms.Button fileScanBtn;
        private System.Windows.Forms.Button showLogBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox displayTextBox;
        private System.Windows.Forms.CheckBox isExpertModeChckbx;
        private System.Windows.Forms.Button ShowDetectionsBtn;
    }
}

