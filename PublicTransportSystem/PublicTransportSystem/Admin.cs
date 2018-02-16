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
    public partial class Admin : Form
    {
       



        public Admin()
        {
            InitializeComponent();
           
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void newLine_Click(object sender, EventArgs e)
        {
            NovaLinija nl = new NovaLinija();
            nl.ShowDialog();
            setRouts();
        }

        private void newStation_Click(object sender, EventArgs e)
        {
            NovaStanica ft = new NovaStanica();
            ft.ShowDialog();
            if (ft.st != null)
            {
                StationModel.InsertStation(ft.st);

                setStations();
            }

        }

        private void setRouts()
        {
            List<RoutView> routs;
            routs = RouteModel.GetAllRoutes();
            dataGridView1.DataSource = routs;
        }
        private void setStations()
        {
            List<Station> routs;
            routs = StationModel.GetAllStations();
            dataGridView1.DataSource = routs;
        }
        private void setvozila()
        {
            List<Vehical> routs;
            routs = VehicalModel.GetAllVehical();
            dataGridView1.DataSource = routs;
        }

        private void listLines_Click(object sender, EventArgs e)
        {
            setRouts();
        }

        private void listStations_Click(object sender, EventArgs e)
        {
            setStations();
        }

        private void listVehicle_Click(object sender, EventArgs e)
        {
            setvozila();
        }

        private void dataGridView1_DataMemberChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void editLine_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null) return;

            Linija st = new Linija(dataGridView1.SelectedRows[0].DataBoundItem as RoutView);
            st.Show();
            
        }

        private void deleteLine_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null) return;

            RoutView st =dataGridView1.SelectedRows[0].DataBoundItem as RoutView;

            RouteModel.DeleteRout(st.Id);

            setRouts();
        }

        private void deleteStation_Click(object sender, EventArgs e)
        {

        }

        private void editStation_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null) return;

            NovaStanica st = new NovaStanica(dataGridView1.SelectedRows[0].DataBoundItem as Station);
            st.ShowDialog();
        }

        private void newVehicle_Click(object sender, EventArgs e)
        {
            Vihecal vs = new Vihecal();
            vs.ShowDialog();
        }
    }
}
