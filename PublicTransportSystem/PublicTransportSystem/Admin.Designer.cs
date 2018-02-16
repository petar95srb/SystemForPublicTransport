namespace PublicTransportSystem
{
    partial class Admin
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
            this.newLine = new System.Windows.Forms.Button();
            this.listLines = new System.Windows.Forms.Button();
            this.deleteLine = new System.Windows.Forms.Button();
            this.editLine = new System.Windows.Forms.Button();
            this.editStation = new System.Windows.Forms.Button();
            this.deleteStation = new System.Windows.Forms.Button();
            this.listStations = new System.Windows.Forms.Button();
            this.newStation = new System.Windows.Forms.Button();
            this.editVehicle = new System.Windows.Forms.Button();
            this.deleteVehicle = new System.Windows.Forms.Button();
            this.listVehicle = new System.Windows.Forms.Button();
            this.newVehicle = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // newLine
            // 
            this.newLine.Location = new System.Drawing.Point(12, 42);
            this.newLine.Name = "newLine";
            this.newLine.Size = new System.Drawing.Size(109, 31);
            this.newLine.TabIndex = 0;
            this.newLine.Text = "Dodaj novu liniju";
            this.newLine.UseVisualStyleBackColor = true;
            this.newLine.Click += new System.EventHandler(this.newLine_Click);
            // 
            // listLines
            // 
            this.listLines.Location = new System.Drawing.Point(12, 12);
            this.listLines.Name = "listLines";
            this.listLines.Size = new System.Drawing.Size(109, 24);
            this.listLines.TabIndex = 1;
            this.listLines.Text = "Lista linija";
            this.listLines.UseVisualStyleBackColor = true;
            this.listLines.Click += new System.EventHandler(this.listLines_Click);
            // 
            // deleteLine
            // 
            this.deleteLine.Location = new System.Drawing.Point(12, 79);
            this.deleteLine.Name = "deleteLine";
            this.deleteLine.Size = new System.Drawing.Size(109, 24);
            this.deleteLine.TabIndex = 2;
            this.deleteLine.Text = "Obrisi liniju";
            this.deleteLine.UseVisualStyleBackColor = true;
            this.deleteLine.Click += new System.EventHandler(this.deleteLine_Click);
            // 
            // editLine
            // 
            this.editLine.Location = new System.Drawing.Point(12, 109);
            this.editLine.Name = "editLine";
            this.editLine.Size = new System.Drawing.Size(109, 24);
            this.editLine.TabIndex = 3;
            this.editLine.Text = "Izmeni liniju";
            this.editLine.UseVisualStyleBackColor = true;
            this.editLine.Click += new System.EventHandler(this.editLine_Click);
            // 
            // editStation
            // 
            this.editStation.Location = new System.Drawing.Point(12, 253);
            this.editStation.Name = "editStation";
            this.editStation.Size = new System.Drawing.Size(109, 24);
            this.editStation.TabIndex = 7;
            this.editStation.Text = "Izmeni stanicu";
            this.editStation.UseVisualStyleBackColor = true;
            this.editStation.Click += new System.EventHandler(this.editStation_Click);
            // 
            // deleteStation
            // 
            this.deleteStation.Location = new System.Drawing.Point(12, 223);
            this.deleteStation.Name = "deleteStation";
            this.deleteStation.Size = new System.Drawing.Size(109, 24);
            this.deleteStation.TabIndex = 6;
            this.deleteStation.Text = "Obrisi stanicu";
            this.deleteStation.UseVisualStyleBackColor = true;
            this.deleteStation.Click += new System.EventHandler(this.deleteStation_Click);
            // 
            // listStations
            // 
            this.listStations.Location = new System.Drawing.Point(12, 156);
            this.listStations.Name = "listStations";
            this.listStations.Size = new System.Drawing.Size(109, 24);
            this.listStations.TabIndex = 5;
            this.listStations.Text = "Lista stanica";
            this.listStations.UseVisualStyleBackColor = true;
            this.listStations.Click += new System.EventHandler(this.listStations_Click);
            // 
            // newStation
            // 
            this.newStation.Location = new System.Drawing.Point(12, 186);
            this.newStation.Name = "newStation";
            this.newStation.Size = new System.Drawing.Size(109, 31);
            this.newStation.TabIndex = 4;
            this.newStation.Text = "Dodaj novu stanicu";
            this.newStation.UseVisualStyleBackColor = true;
            this.newStation.Click += new System.EventHandler(this.newStation_Click);
            // 
            // editVehicle
            // 
            this.editVehicle.Location = new System.Drawing.Point(12, 405);
            this.editVehicle.Name = "editVehicle";
            this.editVehicle.Size = new System.Drawing.Size(109, 24);
            this.editVehicle.TabIndex = 11;
            this.editVehicle.Text = "Izmeni vozilo";
            this.editVehicle.UseVisualStyleBackColor = true;
            // 
            // deleteVehicle
            // 
            this.deleteVehicle.Location = new System.Drawing.Point(12, 375);
            this.deleteVehicle.Name = "deleteVehicle";
            this.deleteVehicle.Size = new System.Drawing.Size(109, 24);
            this.deleteVehicle.TabIndex = 10;
            this.deleteVehicle.Text = "Obrisi vozilo";
            this.deleteVehicle.UseVisualStyleBackColor = true;
            // 
            // listVehicle
            // 
            this.listVehicle.Location = new System.Drawing.Point(12, 308);
            this.listVehicle.Name = "listVehicle";
            this.listVehicle.Size = new System.Drawing.Size(109, 24);
            this.listVehicle.TabIndex = 9;
            this.listVehicle.Text = "Lista vozila";
            this.listVehicle.UseVisualStyleBackColor = true;
            this.listVehicle.Click += new System.EventHandler(this.listVehicle_Click);
            // 
            // newVehicle
            // 
            this.newVehicle.Location = new System.Drawing.Point(12, 338);
            this.newVehicle.Name = "newVehicle";
            this.newVehicle.Size = new System.Drawing.Size(109, 31);
            this.newVehicle.TabIndex = 8;
            this.newVehicle.Text = "Dodaj novo vozilo";
            this.newVehicle.UseVisualStyleBackColor = true;
            this.newVehicle.Click += new System.EventHandler(this.newVehicle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(146, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(690, 380);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.DataMemberChanged += new System.EventHandler(this.dataGridView1_DataMemberChanged);
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 463);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.editVehicle);
            this.Controls.Add(this.deleteVehicle);
            this.Controls.Add(this.listVehicle);
            this.Controls.Add(this.newVehicle);
            this.Controls.Add(this.editStation);
            this.Controls.Add(this.deleteStation);
            this.Controls.Add(this.listStations);
            this.Controls.Add(this.newStation);
            this.Controls.Add(this.editLine);
            this.Controls.Add(this.deleteLine);
            this.Controls.Add(this.listLines);
            this.Controls.Add(this.newLine);
            this.Name = "Admin";
            this.Text = "Admin";
            this.Load += new System.EventHandler(this.Admin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newLine;
        private System.Windows.Forms.Button listLines;
        private System.Windows.Forms.Button deleteLine;
        private System.Windows.Forms.Button editLine;
        private System.Windows.Forms.Button editStation;
        private System.Windows.Forms.Button deleteStation;
        private System.Windows.Forms.Button listStations;
        private System.Windows.Forms.Button newStation;
        private System.Windows.Forms.Button editVehicle;
        private System.Windows.Forms.Button deleteVehicle;
        private System.Windows.Forms.Button listVehicle;
        private System.Windows.Forms.Button newVehicle;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}