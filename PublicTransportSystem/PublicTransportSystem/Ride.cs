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
    public partial class Ride : Form
    {
        RoutView rout;
        public Ride(RoutView rt)
        {
            InitializeComponent();
            rout = rt;
            listBox1.Items.AddRange(RideModel.GetAllRides(rout.Id).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewRide adr = new AddNewRide(rout.Transport);
            adr.ShowDialog();
            updateListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            AddNewRide adr = new AddNewRide(rout.Transport,listBox1.SelectedItem as RideView);
            adr.ShowDialog();
            updateListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;
            RideModel.RemoveRide((listBox1.SelectedItem as RideView).Id);
            updateListBox();
        }

        private void updateListBox()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(RideModel.GetAllRides(rout.Id).ToArray());

        }
    }
}
