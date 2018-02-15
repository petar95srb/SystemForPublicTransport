using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublicTransportSystem
{
    public partial class NovaStanica : Form
    {
        public Station st = null;
        public NovaStanica()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void NovaStanica_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            st = new Station();
            st.Name = txtName.Text != "" ? txtName.Text : null;
            if (st == null) return;
            st.Address = txtAdress.Text != "" ? txtAdress.Text : null;
            if (st == null) return;
            double pom;
            if (!double.TryParse(textBox1.Text, out pom)) return;
            st.Lat = pom;
            if (!double.TryParse(textBox2.Text, out pom)) return;
            st.Lon = pom;

            st.Zone = 1;

            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            st = null;
            this.Close();
        }
    }
}
