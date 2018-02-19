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
    public partial class Time_Table : Form
    {
        List<VihecalType> types = new List<VihecalType>{ new VihecalType { name = "Bus", type = typeof(MongoLayer.Models.Bus) },
                                 {new VihecalType { name="Vagon",type=typeof(MongoLayer.Models.Vagon)}},
                                {new VihecalType { name="Voz",type=typeof(MongoLayer.Models.Locomotiva)}} };

        public Time_Table()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(types.ToArray());
            comboBox2.Enabled = false;
        }

        private void Time_Table_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = RideModel.GetRides(null, null);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var test = comboBox1.SelectedItem as VihecalType;
            if (test == null) return;

            var ts=TransportModel.GetTransport(test.name);

            comboBox2.Enabled = true;
            comboBox2.Items.AddRange(RouteModel.GetAllRoutes(ts.Id.ToString()).ToArray());

            dataGridView1.DataSource = RideModel.GetRides(ts.Id.ToString(), null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var test = comboBox1.SelectedItem as VihecalType;
            if (test == null) return;

            var ts = TransportModel.GetTransport(test.name);



            dataGridView1.DataSource = RideModel.GetRides(ts.Id.ToString(), (comboBox2.SelectedItem as RoutView).Id.ToString());
        }
    }
}
