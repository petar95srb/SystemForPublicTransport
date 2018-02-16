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
    public partial class AddNewRide : Form
    {

        public RideView ride;
        public Transport ts;

        public AddNewRide(Transport trs,RideView rt =null)
        {
            InitializeComponent();
            ts = trs;
            ride = rt;
            if (rt != null)
                initData();
            else
                initNewData();
        }
        private void initNewData()
        {
            List<RoutView> routs;
            routs = RouteModel.GetAllRoutes();

            comboBox1.Items.Add("Routs");
            comboBox1.Items.AddRange(routs.ToArray());
            comboBox1.SelectedIndex = 0;

            List<MongoLayer.Models.Vehical> vc = VehicalModel.GetAllVehical(ts.Id);

            comboBox2.Items.Add("Vihecals");
            comboBox2.Items.AddRange(vc.ToArray());
            comboBox2.SelectedIndex = 0;
        }
        private void AddNewRide_Load(object sender, EventArgs e)
        {

        }

        private void initData()
        {
            dateTimePicker1.Value = ride.StartTime;
            dateTimePicker2.Value = ride.EndTime;

            List<RoutView> routs;
            routs = RouteModel.GetAllRoutes();
            int i;
            for (i = 0; i < routs.Count; i++)
                if (routs[i].Id == ride.Rout.Id)
                    break;

            comboBox1.Items.AddRange(routs.ToArray());
            comboBox1.SelectedIndex = i;

            List<MongoLayer.Models.Vehical> vc = VehicalModel.GetAllVehical(ts.Id);

           
            for (i = 0; i < vc.Count; i++)
                if (vc[i].Id == ride.Vehical.Id)
                    break;

            comboBox2.Items.AddRange(vc.ToArray());
            comboBox2.SelectedIndex = i;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ride = null;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ride == null)
            {
                if (addNewRide())
                    this.Close();
            }
            else if (changeRide())
                this.Close();

        }

        private bool addNewRide()
        {
            ride = new RideView();

            ride.StartTime=dateTimePicker1.Value;

            ride.EndTime = dateTimePicker2.Value;

            RoutView rts = comboBox1.SelectedItem as RoutView;
            if (rts == null) return false;
            ride.Rout = new Route { Id = rts.Id };
            ride.CurrentStation = new Station { Id = rts.Stations[0].Id };

            
            MongoLayer.Models.Vehical vts = comboBox2.SelectedItem as MongoLayer.Models.Vehical;
            if (vts == null) return false;

            ride.Vehical = new Bus { Id = vts.Id }; 

            RideModel.AddNewRide(ride);


            return true;

        }
        private bool changeRide()
        {
            ride.StartTime = dateTimePicker1.Value;

            ride.EndTime = dateTimePicker2.Value;

            RoutView rts = comboBox1.SelectedItem as RoutView;
            if (rts == null) return false;
            ride.Rout.Id = rts.Id;

            MongoLayer.Models.Vehical vts = comboBox2.SelectedItem as MongoLayer.Models.Vehical;
            if (vts == null) return false;
            ride.Vehical.Id = vts.Id;

            RideModel.UpdateRide(ride);

            return true;
        }
    }
}
