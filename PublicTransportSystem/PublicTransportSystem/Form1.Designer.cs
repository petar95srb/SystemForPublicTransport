namespace PublicTransportSystem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Alertsbtn = new System.Windows.Forms.Button();
            this.Adminbtn = new System.Windows.Forms.Button();
            this.Vihecals = new System.Windows.Forms.Button();
            this.Timetable = new System.Windows.Forms.Button();
            this.Client = new System.Windows.Forms.Button();
            this.Transports = new System.Windows.Forms.ComboBox();
            this.Map = new System.Windows.Forms.Panel();
            this.Info = new System.Windows.Forms.Panel();
            this.InitDataBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InitDataBtn);
            this.panel1.Controls.Add(this.Alertsbtn);
            this.panel1.Controls.Add(this.Adminbtn);
            this.panel1.Controls.Add(this.Vihecals);
            this.panel1.Controls.Add(this.Timetable);
            this.panel1.Controls.Add(this.Client);
            this.panel1.Controls.Add(this.Transports);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 438);
            this.panel1.TabIndex = 0;
            // 
            // Alertsbtn
            // 
            this.Alertsbtn.Location = new System.Drawing.Point(39, 234);
            this.Alertsbtn.Name = "Alertsbtn";
            this.Alertsbtn.Size = new System.Drawing.Size(121, 23);
            this.Alertsbtn.TabIndex = 5;
            this.Alertsbtn.Text = "Alerts";
            this.Alertsbtn.UseVisualStyleBackColor = true;
            // 
            // Adminbtn
            // 
            this.Adminbtn.Location = new System.Drawing.Point(39, 193);
            this.Adminbtn.Name = "Adminbtn";
            this.Adminbtn.Size = new System.Drawing.Size(121, 23);
            this.Adminbtn.TabIndex = 4;
            this.Adminbtn.Text = "Admin";
            this.Adminbtn.UseVisualStyleBackColor = true;
            // 
            // Vihecals
            // 
            this.Vihecals.Location = new System.Drawing.Point(39, 152);
            this.Vihecals.Name = "Vihecals";
            this.Vihecals.Size = new System.Drawing.Size(121, 23);
            this.Vihecals.TabIndex = 3;
            this.Vihecals.Text = "Vihecals";
            this.Vihecals.UseVisualStyleBackColor = true;
            // 
            // Timetable
            // 
            this.Timetable.Location = new System.Drawing.Point(39, 113);
            this.Timetable.Name = "Timetable";
            this.Timetable.Size = new System.Drawing.Size(121, 23);
            this.Timetable.TabIndex = 2;
            this.Timetable.Text = "Time table";
            this.Timetable.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            this.Client.Location = new System.Drawing.Point(39, 71);
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(121, 23);
            this.Client.TabIndex = 1;
            this.Client.Text = "Client";
            this.Client.UseVisualStyleBackColor = true;
            // 
            // Transports
            // 
            this.Transports.FormattingEnabled = true;
            this.Transports.Location = new System.Drawing.Point(39, 32);
            this.Transports.Name = "Transports";
            this.Transports.Size = new System.Drawing.Size(121, 21);
            this.Transports.TabIndex = 0;
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(219, 13);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(494, 438);
            this.Map.TabIndex = 1;
            // 
            // Info
            // 
            this.Info.Location = new System.Drawing.Point(720, 13);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(151, 438);
            this.Info.TabIndex = 2;
            // 
            // InitDataBtn
            // 
            this.InitDataBtn.Location = new System.Drawing.Point(39, 273);
            this.InitDataBtn.Name = "InitDataBtn";
            this.InitDataBtn.Size = new System.Drawing.Size(121, 23);
            this.InitDataBtn.TabIndex = 6;
            this.InitDataBtn.Text = "Init Data";
            this.InitDataBtn.UseVisualStyleBackColor = true;
            this.InitDataBtn.Click += new System.EventHandler(this.Init_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 456);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox Transports;
        private System.Windows.Forms.Panel Map;
        private System.Windows.Forms.Panel Info;
        private System.Windows.Forms.Button Alertsbtn;
        private System.Windows.Forms.Button Adminbtn;
        private System.Windows.Forms.Button Vihecals;
        private System.Windows.Forms.Button Timetable;
        private System.Windows.Forms.Button Client;
        private System.Windows.Forms.Button InitDataBtn;
    }
}