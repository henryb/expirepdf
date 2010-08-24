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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Publisher));
            this.ListBox_Files = new System.Windows.Forms.ListBox();
            this.Button_Publish = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateTimePicker_ExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.OpenFileDialog_PDF = new System.Windows.Forms.OpenFileDialog();
            this.TabControl_License = new System.Windows.Forms.TabControl();
            this.TabPage_Basic = new System.Windows.Forms.TabPage();
            this.TextBox_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DateTimePicker_AvailabilityDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TabPage_Advanced = new System.Windows.Forms.TabPage();
            this.Button_RemoveImage = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.PictureBox_Image = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Button_AddImage = new System.Windows.Forms.Button();
            this.TextBox_Website = new System.Windows.Forms.TextBox();
            this.TextBox_Message = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Button_AddFile = new System.Windows.Forms.Button();
            this.Button_RemoveFile = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.OpenFileDialog_PNG = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.TabControl_License.SuspendLayout();
            this.TabPage_Basic.SuspendLayout();
            this.TabPage_Advanced.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBox_Files
            // 
            this.ListBox_Files.AllowDrop = true;
            this.ListBox_Files.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBox_Files.FormattingEnabled = true;
            this.ListBox_Files.Location = new System.Drawing.Point(4, 635);
            this.ListBox_Files.Name = "ListBox_Files";
            this.ListBox_Files.Size = new System.Drawing.Size(802, 186);
            this.ListBox_Files.TabIndex = 0;
            this.ListBox_Files.DragDrop += new System.Windows.Forms.DragEventHandler(this.ListBox_Files_DragDrop);
            this.ListBox_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.ListBox_Files_DragEnter);
            // 
            // Button_Publish
            // 
            this.Button_Publish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Publish.Location = new System.Drawing.Point(731, 558);
            this.Button_Publish.Name = "Button_Publish";
            this.Button_Publish.Size = new System.Drawing.Size(75, 72);
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
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
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
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // DateTimePicker_ExpirationDate
            // 
            this.DateTimePicker_ExpirationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePicker_ExpirationDate.Location = new System.Drawing.Point(543, 72);
            this.DateTimePicker_ExpirationDate.Name = "DateTimePicker_ExpirationDate";
            this.DateTimePicker_ExpirationDate.Size = new System.Drawing.Size(245, 20);
            this.DateTimePicker_ExpirationDate.TabIndex = 5;
            // 
            // OpenFileDialog_PDF
            // 
            this.OpenFileDialog_PDF.Filter = "PDF files|*.pdf";
            this.OpenFileDialog_PDF.Multiselect = true;
            this.OpenFileDialog_PDF.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_PDF_FileOk);
            // 
            // TabControl_License
            // 
            this.TabControl_License.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl_License.Controls.Add(this.TabPage_Basic);
            this.TabControl_License.Controls.Add(this.TabPage_Advanced);
            this.TabControl_License.Location = new System.Drawing.Point(4, 156);
            this.TabControl_License.Name = "TabControl_License";
            this.TabControl_License.SelectedIndex = 0;
            this.TabControl_License.Size = new System.Drawing.Size(802, 330);
            this.TabControl_License.TabIndex = 10;
            // 
            // TabPage_Basic
            // 
            this.TabPage_Basic.Controls.Add(this.TextBox_Password);
            this.TabPage_Basic.Controls.Add(this.label2);
            this.TabPage_Basic.Controls.Add(this.label12);
            this.TabPage_Basic.Controls.Add(this.DateTimePicker_AvailabilityDate);
            this.TabPage_Basic.Controls.Add(this.label11);
            this.TabPage_Basic.Controls.Add(this.label1);
            this.TabPage_Basic.Controls.Add(this.DateTimePicker_ExpirationDate);
            this.TabPage_Basic.Controls.Add(this.label14);
            this.TabPage_Basic.Controls.Add(this.label15);
            this.TabPage_Basic.Controls.Add(this.label5);
            this.TabPage_Basic.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Basic.Name = "TabPage_Basic";
            this.TabPage_Basic.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Basic.Size = new System.Drawing.Size(794, 304);
            this.TabPage_Basic.TabIndex = 0;
            this.TabPage_Basic.Text = "Basic";
            this.TabPage_Basic.UseVisualStyleBackColor = true;
            // 
            // TextBox_Password
            // 
            this.TextBox_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Password.Location = new System.Drawing.Point(543, 121);
            this.TextBox_Password.Name = "TextBox_Password";
            this.TextBox_Password.Size = new System.Drawing.Size(245, 20);
            this.TextBox_Password.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(2, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(789, 23);
            this.label2.TabIndex = 38;
            this.label2.Text = "Please enter a password for additional protection:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(2, 95);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(789, 23);
            this.label12.TabIndex = 37;
            this.label12.Text = "Password Protection";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DateTimePicker_AvailabilityDate
            // 
            this.DateTimePicker_AvailabilityDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimePicker_AvailabilityDate.Location = new System.Drawing.Point(543, 26);
            this.DateTimePicker_AvailabilityDate.Name = "DateTimePicker_AvailabilityDate";
            this.DateTimePicker_AvailabilityDate.Size = new System.Drawing.Size(247, 20);
            this.DateTimePicker_AvailabilityDate.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.DarkGray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(2, 26);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(789, 23);
            this.label11.TabIndex = 32;
            this.label11.Text = "Please select the date that you wish this content to be made available:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(789, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Availability Date:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.BackColor = System.Drawing.Color.DarkGray;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(2, 72);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(789, 23);
            this.label14.TabIndex = 36;
            this.label14.Text = "Please select the date that you wish this content to expire:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(2, 49);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(789, 23);
            this.label15.TabIndex = 35;
            this.label15.Text = "Expiration Date:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(2, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(789, 160);
            this.label5.TabIndex = 39;
            // 
            // TabPage_Advanced
            // 
            this.TabPage_Advanced.Controls.Add(this.Button_RemoveImage);
            this.TabPage_Advanced.Controls.Add(this.label17);
            this.TabPage_Advanced.Controls.Add(this.PictureBox_Image);
            this.TabPage_Advanced.Controls.Add(this.label4);
            this.TabPage_Advanced.Controls.Add(this.label18);
            this.TabPage_Advanced.Controls.Add(this.Button_AddImage);
            this.TabPage_Advanced.Controls.Add(this.TextBox_Website);
            this.TabPage_Advanced.Controls.Add(this.TextBox_Message);
            this.TabPage_Advanced.Controls.Add(this.label13);
            this.TabPage_Advanced.Controls.Add(this.label16);
            this.TabPage_Advanced.Controls.Add(this.label3);
            this.TabPage_Advanced.Controls.Add(this.label19);
            this.TabPage_Advanced.Controls.Add(this.label20);
            this.TabPage_Advanced.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Advanced.Name = "TabPage_Advanced";
            this.TabPage_Advanced.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Advanced.Size = new System.Drawing.Size(794, 304);
            this.TabPage_Advanced.TabIndex = 1;
            this.TabPage_Advanced.Text = "Advanced";
            this.TabPage_Advanced.UseVisualStyleBackColor = true;
            // 
            // Button_RemoveImage
            // 
            this.Button_RemoveImage.Location = new System.Drawing.Point(87, 209);
            this.Button_RemoveImage.Name = "Button_RemoveImage";
            this.Button_RemoveImage.Size = new System.Drawing.Size(75, 72);
            this.Button_RemoveImage.TabIndex = 42;
            this.Button_RemoveImage.Text = "Remove";
            this.Button_RemoveImage.UseVisualStyleBackColor = true;
            this.Button_RemoveImage.Click += new System.EventHandler(this.Button_RemoveImage_Click);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(2, 117);
            this.label17.Margin = new System.Windows.Forms.Padding(0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(789, 23);
            this.label17.TabIndex = 35;
            this.label17.Text = "Website:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PictureBox_Image
            // 
            this.PictureBox_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox_Image.BackColor = System.Drawing.Color.DarkGray;
            this.PictureBox_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PictureBox_Image.Location = new System.Drawing.Point(582, 189);
            this.PictureBox_Image.Name = "PictureBox_Image";
            this.PictureBox_Image.Size = new System.Drawing.Size(206, 109);
            this.PictureBox_Image.TabIndex = 7;
            this.PictureBox_Image.TabStop = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(2, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(789, 23);
            this.label4.TabIndex = 38;
            this.label4.Text = "Please select an image to display when this content is opened:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(2, 163);
            this.label18.Margin = new System.Windows.Forms.Padding(0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(789, 23);
            this.label18.TabIndex = 37;
            this.label18.Text = "Image:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Button_AddImage
            // 
            this.Button_AddImage.Location = new System.Drawing.Point(6, 209);
            this.Button_AddImage.Name = "Button_AddImage";
            this.Button_AddImage.Size = new System.Drawing.Size(75, 72);
            this.Button_AddImage.TabIndex = 4;
            this.Button_AddImage.Text = "Add";
            this.Button_AddImage.UseVisualStyleBackColor = true;
            this.Button_AddImage.Click += new System.EventHandler(this.Button_AddImage_Click);
            // 
            // TextBox_Website
            // 
            this.TextBox_Website.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Website.Location = new System.Drawing.Point(438, 140);
            this.TextBox_Website.Name = "TextBox_Website";
            this.TextBox_Website.Size = new System.Drawing.Size(350, 20);
            this.TextBox_Website.TabIndex = 3;
            // 
            // TextBox_Message
            // 
            this.TextBox_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox_Message.Location = new System.Drawing.Point(438, 26);
            this.TextBox_Message.Multiline = true;
            this.TextBox_Message.Name = "TextBox_Message";
            this.TextBox_Message.Size = new System.Drawing.Size(350, 88);
            this.TextBox_Message.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.DarkGray;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(2, 26);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(789, 23);
            this.label13.TabIndex = 34;
            this.label13.Text = "Please enter a message to display when this content is opened:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(2, 3);
            this.label16.Margin = new System.Windows.Forms.Padding(0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(789, 23);
            this.label16.TabIndex = 33;
            this.label16.Text = "Message:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(2, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(789, 23);
            this.label3.TabIndex = 36;
            this.label3.Text = "Please enter a website to display when this content is opened:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BackColor = System.Drawing.Color.DarkGray;
            this.label19.Location = new System.Drawing.Point(3, 209);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(788, 92);
            this.label19.TabIndex = 40;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.BackColor = System.Drawing.Color.DarkGray;
            this.label20.Location = new System.Drawing.Point(2, 49);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(789, 68);
            this.label20.TabIndex = 41;
            // 
            // Button_AddFile
            // 
            this.Button_AddFile.Location = new System.Drawing.Point(4, 558);
            this.Button_AddFile.Name = "Button_AddFile";
            this.Button_AddFile.Size = new System.Drawing.Size(75, 71);
            this.Button_AddFile.TabIndex = 12;
            this.Button_AddFile.Text = "Add";
            this.Button_AddFile.UseVisualStyleBackColor = true;
            this.Button_AddFile.Click += new System.EventHandler(this.Button_AddFile_Click);
            // 
            // Button_RemoveFile
            // 
            this.Button_RemoveFile.Location = new System.Drawing.Point(85, 558);
            this.Button_RemoveFile.Name = "Button_RemoveFile";
            this.Button_RemoveFile.Size = new System.Drawing.Size(75, 72);
            this.Button_RemoveFile.TabIndex = 13;
            this.Button_RemoveFile.Text = "Remove";
            this.Button_RemoveFile.UseVisualStyleBackColor = true;
            this.Button_RemoveFile.Click += new System.EventHandler(this.Button_RemoveFile_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(810, 43);
            this.label8.TabIndex = 15;
            this.label8.Text = "License:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.DarkGray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(0, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(810, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Please enter the license you wish to use below:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.DodgerBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(810, 63);
            this.label9.TabIndex = 17;
            this.label9.Text = "ExpirePDF Publisher";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkGray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(0, 532);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(810, 23);
            this.label7.TabIndex = 19;
            this.label7.Text = "Please select the files you wish to publish below.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 489);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(810, 43);
            this.label10.TabIndex = 18;
            this.label10.Text = "Files:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.DodgerBlue;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(750, 24);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // OpenFileDialog_PNG
            // 
            this.OpenFileDialog_PNG.Filter = "PNG files|*.png";
            this.OpenFileDialog_PNG.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_PNG_FileOk);
            // 
            // Publisher
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(810, 833);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Button_RemoveFile);
            this.Controls.Add(this.Button_AddFile);
            this.Controls.Add(this.TabControl_License);
            this.Controls.Add(this.Button_Publish);
            this.Controls.Add(this.ListBox_Files);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Publisher";
            this.Text = "ExpirePDF Publisher";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TabControl_License.ResumeLayout(false);
            this.TabPage_Basic.ResumeLayout(false);
            this.TabPage_Basic.PerformLayout();
            this.TabPage_Advanced.ResumeLayout(false);
            this.TabPage_Advanced.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.DateTimePicker DateTimePicker_ExpirationDate;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_PDF;
        private System.Windows.Forms.TabControl TabControl_License;
        private System.Windows.Forms.TabPage TabPage_Basic;
        private System.Windows.Forms.TabPage TabPage_Advanced;
        private System.Windows.Forms.TextBox TextBox_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DateTimePicker_AvailabilityDate;
        private System.Windows.Forms.Button Button_AddImage;
        private System.Windows.Forms.TextBox TextBox_Website;
        private System.Windows.Forms.TextBox TextBox_Message;
        private System.Windows.Forms.Button Button_AddFile;
        private System.Windows.Forms.Button Button_RemoveFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox PictureBox_Image;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button Button_RemoveImage;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog_PNG;
    }
}

