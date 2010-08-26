namespace ExpirePDFViewer
{
    partial class Viewer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.Label_Message = new System.Windows.Forms.Label();
            this.PictureBox_Image = new System.Windows.Forms.PictureBox();
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.Label_Password = new System.Windows.Forms.Label();
            this.Button_OK = new System.Windows.Forms.Button();
            this.NotifyIcon_Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.Timer_Hide = new System.Windows.Forms.Timer(this.components);
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.LinkLabel_Website = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_Message
            // 
            this.Label_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Message.Location = new System.Drawing.Point(12, 410);
            this.Label_Message.Name = "Label_Message";
            this.Label_Message.Size = new System.Drawing.Size(395, 46);
            this.Label_Message.TabIndex = 0;
            this.Label_Message.Text = "ExpirePDF: All Rights Reserved 2010";
            this.Label_Message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PictureBox_Image
            // 
            this.PictureBox_Image.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBox_Image.BackgroundImage")));
            this.PictureBox_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBox_Image.Location = new System.Drawing.Point(12, 12);
            this.PictureBox_Image.Name = "PictureBox_Image";
            this.PictureBox_Image.Size = new System.Drawing.Size(395, 395);
            this.PictureBox_Image.TabIndex = 1;
            this.PictureBox_Image.TabStop = false;
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.Location = new System.Drawing.Point(151, 486);
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.Size = new System.Drawing.Size(155, 20);
            this.TextBox_Password.TabIndex = 2;
            // 
            // Label_Password
            // 
            this.Label_Password.AutoSize = true;
            this.Label_Password.Location = new System.Drawing.Point(89, 486);
            this.Label_Password.Name = "Label_Password";
            this.Label_Password.Size = new System.Drawing.Size(56, 13);
            this.Label_Password.TabIndex = 3;
            this.Label_Password.Text = "Password:";
            // 
            // Button_OK
            // 
            this.Button_OK.Location = new System.Drawing.Point(114, 509);
            this.Button_OK.Name = "Button_OK";
            this.Button_OK.Size = new System.Drawing.Size(75, 23);
            this.Button_OK.TabIndex = 4;
            this.Button_OK.Text = "OK";
            this.Button_OK.UseVisualStyleBackColor = true;
            this.Button_OK.Click += new System.EventHandler(this.Button_OK_Click);
            // 
            // NotifyIcon_Tray
            // 
            this.NotifyIcon_Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon_Tray.Icon")));
            this.NotifyIcon_Tray.Text = "ExpirePDF Viewer";
            this.NotifyIcon_Tray.Visible = true;
            // 
            // Timer_Hide
            // 
            this.Timer_Hide.Tick += new System.EventHandler(this.Timer_Hide_Tick);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(195, 509);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Button_Cancel.TabIndex = 5;
            this.Button_Cancel.Text = "Cancel";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // LinkLabel_Website
            // 
            this.LinkLabel_Website.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkLabel_Website.Location = new System.Drawing.Point(12, 456);
            this.LinkLabel_Website.Name = "LinkLabel_Website";
            this.LinkLabel_Website.Size = new System.Drawing.Size(395, 13);
            this.LinkLabel_Website.TabIndex = 6;
            this.LinkLabel_Website.TabStop = true;
            this.LinkLabel_Website.Text = "http://www.drexel.edu";
            this.LinkLabel_Website.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 537);
            this.Controls.Add(this.LinkLabel_Website);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_OK);
            this.Controls.Add(this.Label_Password);
            this.Controls.Add(this.TextBox_Password);
            this.Controls.Add(this.PictureBox_Image);
            this.Controls.Add(this.Label_Message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Viewer";
            this.Text = "ExpirePDF Viewer";
            this.Load += new System.EventHandler(this.Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Message;
        private System.Windows.Forms.PictureBox PictureBox_Image;
        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.Label Label_Password;
        private System.Windows.Forms.Button Button_OK;
        private System.Windows.Forms.NotifyIcon NotifyIcon_Tray;
        private System.Windows.Forms.Timer Timer_Hide;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.LinkLabel LinkLabel_Website;
    }
}

