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
            this.SuspendLayout();
            // 
            // headerLbl
            // 
            this.headerLbl.AutoSize = true;
            this.headerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.headerLbl.Location = new System.Drawing.Point(451, 47);
            this.headerLbl.Name = "headerLbl";
            this.headerLbl.Size = new System.Drawing.Size(437, 76);
            this.headerLbl.TabIndex = 0;
            this.headerLbl.Text = "O2 Anti Virus";
            this.headerLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // folderScanBtn
            // 
            this.folderScanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.folderScanBtn.Location = new System.Drawing.Point(96, 158);
            this.folderScanBtn.Name = "folderScanBtn";
            this.folderScanBtn.Size = new System.Drawing.Size(284, 99);
            this.folderScanBtn.TabIndex = 1;
            this.folderScanBtn.Text = "Scan a folder";
            this.folderScanBtn.UseVisualStyleBackColor = true;
            this.folderScanBtn.Click += new System.EventHandler(this.folderScanBtn_Click);
            // 
            // fileScanBtn
            // 
            this.fileScanBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.fileScanBtn.Location = new System.Drawing.Point(96, 281);
            this.fileScanBtn.Name = "fileScanBtn";
            this.fileScanBtn.Size = new System.Drawing.Size(284, 99);
            this.fileScanBtn.TabIndex = 2;
            this.fileScanBtn.Text = "Scan a file";
            this.fileScanBtn.UseVisualStyleBackColor = true;
            this.fileScanBtn.Click += new System.EventHandler(this.fileScanBtn_Click);
            // 
            // showLogBtn
            // 
            this.showLogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.showLogBtn.Location = new System.Drawing.Point(96, 404);
            this.showLogBtn.Name = "showLogBtn";
            this.showLogBtn.Size = new System.Drawing.Size(284, 99);
            this.showLogBtn.TabIndex = 3;
            this.showLogBtn.Text = "Show log";
            this.showLogBtn.UseVisualStyleBackColor = true;
            this.showLogBtn.Click += new System.EventHandler(this.showLogBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.clearBtn.Location = new System.Drawing.Point(96, 526);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(284, 99);
            this.clearBtn.TabIndex = 4;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(501, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "Notifications:";
            // 
            // displayTextBox
            // 
            this.displayTextBox.Location = new System.Drawing.Point(507, 203);
            this.displayTextBox.Multiline = true;
            this.displayTextBox.Name = "displayTextBox";
            this.displayTextBox.Size = new System.Drawing.Size(768, 427);
            this.displayTextBox.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1391, 673);
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
    }
}

