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
            this.InitDataBtn = new System.Windows.Forms.Button();
            this.Alertsbtn = new System.Windows.Forms.Button();
            this.Adminbtn = new System.Windows.Forms.Button();
            this.Vihecals = new System.Windows.Forms.Button();
            this.Timetable = new System.Windows.Forms.Button();
            this.Client = new System.Windows.Forms.Button();
            this.Transports = new System.Windows.Forms.ComboBox();
            this.Map = new System.Windows.Forms.Panel();
            this.Info = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Info.SuspendLayout();
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
            this.Adminbtn.Click += new System.EventHandler(this.Adminbtn_Click);
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
            this.Client.Click += new System.EventHandler(this.Client_Click);
            // 
            // Transports
            // 
            this.Transports.FormattingEnabled = true;
            this.Transports.Location = new System.Drawing.Point(39, 32);
            this.Transports.Name = "Transports";
            this.Transports.Size = new System.Drawing.Size(121, 21);
            this.Transports.TabIndex = 0;
            this.Transports.SelectedIndexChanged += new System.EventHandler(this.Transports_SelectedIndexChanged);
            // 
            // Map
            // 
            this.Map.Location = new System.Drawing.Point(219, 13);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(494, 438);
            this.Map.TabIndex = 1;
            this.Map.Paint += new System.Windows.Forms.PaintEventHandler(this.Map_Paint);
            this.Map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Map_MouseClick);
            // 
            // Info
            // 
            this.Info.Controls.Add(this.label3);
            this.Info.Controls.Add(this.label2);
            this.Info.Controls.Add(this.label1);
            this.Info.Location = new System.Drawing.Point(720, 13);
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(151, 438);
            this.Info.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
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
            this.Text = "Transport system";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.panel1.ResumeLayout(false);
            this.Info.ResumeLayout(false);
            this.Info.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}