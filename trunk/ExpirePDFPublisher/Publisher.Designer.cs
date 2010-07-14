namespace ExpirePDFPublisher
{
    partial class Publisher
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
            this.ListBox_Files = new System.Windows.Forms.ListBox();
            this.Button_Publish = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.DateTimePicker_ReleaseDate = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker_ExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox_Files
            // 
            this.ListBox_Files.AllowDrop = true;
            this.ListBox_Files.FormattingEnabled = true;
            this.ListBox_Files.Location = new System.Drawing.Point(10, 27);
            this.ListBox_Files.Name = "ListBox_Files";
            this.ListBox_Files.Size = new System.Drawing.Size(513, 264);
            this.ListBox_Files.TabIndex = 0;
            this.ListBox_Files.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBox_Files_DragDrop);
            this.ListBox_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox_Files_DragEnter);
            // 
            // Button_Publish
            // 
            this.Button_Publish.Location = new System.Drawing.Point(448, 297);
            this.Button_Publish.Name = "Button_Publish";
            this.Button_Publish.Size = new System.Drawing.Size(75, 75);
            this.Button_Publish.TabIndex = 1;
            this.Button_Publish.Text = "Publish";
            this.Button_Publish.UseVisualStyleBackColor = true;
            this.Button_Publish.Click += new System.EventHandler(this.Button_Publish_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fToolStripMenuItem
            // 
            this.fToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fToolStripMenuItem.Name = "fToolStripMenuItem";
            this.fToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Release Date:";
            // 
            // DateTimePicker_ReleaseDate
            // 
            this.DateTimePicker_ReleaseDate.Location = new System.Drawing.Point(178, 304);
            this.DateTimePicker_ReleaseDate.Name = "DateTimePicker_ReleaseDate";
            this.DateTimePicker_ReleaseDate.Size = new System.Drawing.Size(200, 20);
            this.DateTimePicker_ReleaseDate.TabIndex = 4;
            // 
            // DateTimePicker_ExpirationDate
            // 
            this.DateTimePicker_ExpirationDate.Location = new System.Drawing.Point(178, 329);
            this.DateTimePicker_ExpirationDate.Name = "DateTimePicker_ExpirationDate";
            this.DateTimePicker_ExpirationDate.Size = new System.Drawing.Size(200, 20);
            this.DateTimePicker_ExpirationDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Expiration Date:";
            // 
            // Publisher
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 384);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DateTimePicker_ExpirationDate);
            this.Controls.Add(this.DateTimePicker_ReleaseDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Publish);
            this.Controls.Add(this.ListBox_Files);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Publisher";
            this.Text = "ExpirePDF Publisher";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_Files;
        private System.Windows.Forms.Button Button_Publish;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimePicker_ReleaseDate;
        private System.Windows.Forms.DateTimePicker DateTimePicker_ExpirationDate;
        private System.Windows.Forms.Label label2;
    }
}

