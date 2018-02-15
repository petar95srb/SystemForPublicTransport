using MongoLayer.ModelViews;
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
    public partial class Linija : Form
    {
        RoutView route;
        public Linija(RoutView route)
        {
            InitializeComponent();
            this.route = route;
            listBox1.Items.AddRange(route.Stations.ToArray());
        }

        private void btnDodajStanicu_Click(object sender, EventArgs e)
        {

        }
    }
}
