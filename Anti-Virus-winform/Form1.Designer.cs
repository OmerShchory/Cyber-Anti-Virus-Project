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
            printLogBtn = new Button();
            displayTextBox = new TextBox();
            clearBtn = new Button();
            notificationsLabel = new Label();
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
            manualFolderScanBtn.Location = new Point(69, 227);
            manualFolderScanBtn.Margin = new Padding(3, 4, 3, 4);
            manualFolderScanBtn.Name = "manualFolderScanBtn";
            manualFolderScanBtn.Size = new Size(256, 85);
            manualFolderScanBtn.TabIndex = 2;
            manualFolderScanBtn.Text = "Manual Folder Scan";
            manualFolderScanBtn.UseVisualStyleBackColor = true;
            manualFolderScanBtn.Click += manualFolderScanBtn_Click;
            // 
            // manualFileScanBtn
            // 
            manualFileScanBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            manualFileScanBtn.Location = new Point(69, 333);
            manualFileScanBtn.Name = "manualFileScanBtn";
            manualFileScanBtn.Size = new Size(256, 85);
            manualFileScanBtn.TabIndex = 3;
            manualFileScanBtn.Text = "Manual File Scan";
            manualFileScanBtn.UseVisualStyleBackColor = true;
            manualFileScanBtn.Click += manualFileScanBtn_Click;
            // 
            // printLogBtn
            // 
            printLogBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            printLogBtn.Location = new Point(69, 448);
            printLogBtn.Name = "printLogBtn";
            printLogBtn.Size = new Size(256, 85);
            printLogBtn.TabIndex = 4;
            printLogBtn.Text = "Show Log";
            printLogBtn.UseVisualStyleBackColor = true;
            printLogBtn.Click += printLogBtn_Click;
            // 
            // displayTextBox
            // 
            displayTextBox.Location = new Point(427, 286);
            displayTextBox.Multiline = true;
            displayTextBox.Name = "displayTextBox";
            displayTextBox.Size = new Size(739, 406);
            displayTextBox.TabIndex = 5;
            // 
            // clearBtn
            // 
            clearBtn.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            clearBtn.Location = new Point(69, 566);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(256, 85);
            clearBtn.TabIndex = 6;
            clearBtn.Text = "Clear";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // notificationsLabel
            // 
            notificationsLabel.AutoSize = true;
            notificationsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            notificationsLabel.Location = new Point(427, 227);
            notificationsLabel.Name = "notificationsLabel";
            notificationsLabel.Size = new Size(168, 37);
            notificationsLabel.TabIndex = 7;
            notificationsLabel.Text = "Notifications";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1231, 739);
            Controls.Add(notificationsLabel);
            Controls.Add(clearBtn);
            Controls.Add(displayTextBox);
            Controls.Add(printLogBtn);
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
        private Button printLogBtn;
        private TextBox displayTextBox;
        private Button clearBtn;
        private Label notificationsLabel;
    }
}