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
    public partial class Stanica : Form
    {
        public Stanica()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtName.ReadOnly = false;
            txtAdress.ReadOnly = false;
            txtNapomene.ReadOnly = false;
            
        }

        private void Stanica_Load(object sender, EventArgs e)
        {
            
        }
    }
}
