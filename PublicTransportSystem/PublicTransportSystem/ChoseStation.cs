using MongoLayer.ManipulationModels;
using MongoLayer.Models;
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
    public partial class ChoseStation : Form
    {
        RoutView route;
        public Station station=null;
        public ChoseStation(RoutView st=null)
        {
            InitializeComponent();
            route = st;
        }

        private void ChoseStation_Load(object sender, EventArgs e)
        {
            var sta = StationModel.NotInRouteStations(route!=null?route.Id.ToString():null);
            listBox1.Items.AddRange(sta.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NovaStanica ft = new NovaStanica();
            ft.ShowDialog();
            if(ft.st!=null)
            {
                station = ft.st;
                station=StationModel.InsertStation(ft.st);

                var sta = StationModel.NotInRouteStations(route != null ? route.Id.ToString() : null);
                listBox1.Items.Clear();
                listBox1.Items.AddRange(sta.ToArray());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (station != null)
                this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            station = null;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            station = listBox1.SelectedItem as Station;
        }
    }
}
