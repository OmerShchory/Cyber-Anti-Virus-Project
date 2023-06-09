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
            this.SuspendLayout();
            // 
            // headerLbl
            // 
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.headerLbl.Location = new System.Drawing.Point(338, 38);
            this.headerLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(358, 63);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "O2 Anti Virus";
            this.headerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // folderScanBtn
            // 
            this.folderScanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.folderScanBtn.Location = new System.Drawing.Point(72, 128);
            this.folderScanBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.folderScanBtn.Name = "folderScanBtn";
            this.folderScanBtn.Size = new System.Drawing.Size(213, 80);
            this.folderScanBtn.TabIndex = 1;
            this.folderScanBtn.Text = "Scan a folder";
            this.folderScanBtn.UseVisualStyleBackColor = true;
            this.folderScanBtn.Click += new System.EventHandler(this.folderScanBtn_Click);
            // 
            // fileScanBtn
            // 
            this.fileScanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.fileScanBtn.Location = new System.Drawing.Point(72, 228);
            this.fileScanBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.fileScanBtn.Name = "fileScanBtn";
            this.fileScanBtn.Size = new System.Drawing.Size(213, 80);
            this.fileScanBtn.TabIndex = 2;
            this.fileScanBtn.Text = "Scan a file";
            this.fileScanBtn.UseVisualStyleBackColor = true;
            this.fileScanBtn.Click += new System.EventHandler(this.fileScanBtn_Click);
            // 
            // showLogBtn
            // 
            this.showLogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.showLogBtn.Location = new System.Drawing.Point(72, 328);
            this.showLogBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.showLogBtn.Name = "showLogBtn";
            this.showLogBtn.Size = new System.Drawing.Size(213, 80);
            this.showLogBtn.TabIndex = 3;
            this.showLogBtn.Text = "Show log";
            this.showLogBtn.UseVisualStyleBackColor = true;
            this.showLogBtn.Click += new System.EventHandler(this.showLogBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.clearBtn.Location = new System.Drawing.Point(72, 427);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(213, 80);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(376, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Notifications:";
            // 
            // displayTextBox
            // 
            this.displayTextBox.Location = new System.Drawing.Point(380, 165);
            this.displayTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.displayTextBox.Multiline = true;
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.displayTextBox.Size = new System.Drawing.Size(894, 348);
            this.displayTextBox.TabIndex = 6;
            // 
            // isExpertModeChckbx
            // 
            this.isExpertModeChckbx.AutoSize = true;
            this.isExpertModeChckbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.isExpertModeChckbx.Location = new System.Drawing.Point(1120, 124);
            this.isExpertModeChckbx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.isExpertModeChckbx.Name = "isExpertModeChckbx";
            this.isExpertModeChckbx.Size = new System.Drawing.Size(154, 30);
            this.isExpertModeChckbx.TabIndex = 7;
            this.isExpertModeChckbx.Text = "Expert Mode";
            this.isExpertModeChckbx.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.isExpertModeChckbx.UseVisualStyleBackColor = true;
            this.isExpertModeChckbx.CheckedChanged += new System.EventHandler(this.isExpertModeChckbx_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 547);
            this.Controls.Add(this.isExpertModeChckbx);
            this.Controls.Add(this.displayTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.showLogBtn);
            this.Controls.Add(this.fileScanBtn);
            this.Controls.Add(this.folderScanBtn);
            this.Controls.Add(this.headerLbl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}

