using MongoLayer.ManipulationModels;
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
            int poz;
            if (int.TryParse(txtDodajStanicu.Text, out poz))
            {
                if (poz < 0 || poz > route.Stations.Count)
                    return;
            }
            else
                return;
            ChoseStation ss = new ChoseStation(route);
            ss.ShowDialog();
            if(ss.station!=null)
            {
                route= RouteModel.Rout(route.Id, ss.station.Id, poz);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(route.Stations.ToArray());
            }

        }
    }
}
