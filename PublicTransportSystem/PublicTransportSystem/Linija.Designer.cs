namespace PublicTransportSystem
{
    partial class Linija
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBroj = new System.Windows.Forms.TextBox();
            this.btnDodajStanicu = new System.Windows.Forms.Button();
            this.btnObrisiStanicu = new System.Windows.Forms.Button();
            this.txtDodajStanicu = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(150, 410);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(137, 43);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Close";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(125, 137);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(177, 186);
            this.listBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stanice:";
            this.label1.UseMnemonic = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(150, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(66, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "LINIJA";
            // 
            // txtBroj
            // 
            this.txtBroj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBroj.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBroj.Location = new System.Drawing.Point(222, 32);
            this.txtBroj.Name = "txtBroj";
            this.txtBroj.ReadOnly = true;
            this.txtBroj.Size = new System.Drawing.Size(65, 20);
            this.txtBroj.TabIndex = 7;
            this.txtBroj.Text = "broj";
            // 
            // btnDodajStanicu
            // 
            this.btnDodajStanicu.Location = new System.Drawing.Point(339, 221);
            this.btnDodajStanicu.Name = "btnDodajStanicu";
            this.btnDodajStanicu.Size = new System.Drawing.Size(109, 28);
            this.btnDodajStanicu.TabIndex = 8;
            this.btnDodajStanicu.Text = "Dodaj stanicu";
            this.btnDodajStanicu.UseVisualStyleBackColor = true;
            this.btnDodajStanicu.Click += new System.EventHandler(this.btnDodajStanicu_Click);
            // 
            // btnObrisiStanicu
            // 
            this.btnObrisiStanicu.Location = new System.Drawing.Point(339, 265);
            this.btnObrisiStanicu.Name = "btnObrisiStanicu";
            this.btnObrisiStanicu.Size = new System.Drawing.Size(109, 28);
            this.btnObrisiStanicu.TabIndex = 9;
            this.btnObrisiStanicu.Text = "Obrisi stanicu";
            this.btnObrisiStanicu.UseVisualStyleBackColor = true;
            this.btnObrisiStanicu.Click += new System.EventHandler(this.btnObrisiStanicu_Click);
            // 
            // txtDodajStanicu
            // 
            this.txtDodajStanicu.Location = new System.Drawing.Point(339, 159);
            this.txtDodajStanicu.Name = "txtDodajStanicu";
            this.txtDodajStanicu.Size = new System.Drawing.Size(109, 20);
            this.txtDodajStanicu.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(339, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Rides";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Linija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 465);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDodajStanicu);
            this.Controls.Add(this.btnObrisiStanicu);
            this.Controls.Add(this.btnDodajStanicu);
            this.Controls.Add(this.txtBroj);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnEdit);
            this.Name = "Linija";
            this.Text = "Linija";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtBroj;
        private System.Windows.Forms.Button btnDodajStanicu;
        private System.Windows.Forms.Button btnObrisiStanicu;
        private System.Windows.Forms.TextBox txtDodajStanicu;
        private System.Windows.Forms.Button button1;
    }
}