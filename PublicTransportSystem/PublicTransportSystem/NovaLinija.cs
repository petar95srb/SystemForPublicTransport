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
    public partial class NovaLinija : Form
    {

        private List<TransportView> transports;
        private List<Station> stations;


        private RoutView newRout;

        public NovaLinija()
        {
            InitializeComponent();
            newRout = null;
        }

        private void NovaLinija_Load(object sender, EventArgs e)
        {
            transports = TransportModel.GetAllTransports();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Transports");
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.AddRange(transports.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChoseStation st = new ChoseStation();

            st.ShowDialog();

            if(st.station!=null)
            {
                listBox1.Items.Add(st.station);
            }

           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            newRout = new RoutView();

            int br;
            if (!int.TryParse(txtBroj.Text, out br)) return;
            newRout.Line = br;

            TransportView test = comboBox1.SelectedItem as TransportView;
            if (test == null) return;

            newRout.Transport = new Transport { Id = test.Id };

            newRout.Stations = listBox1.Items.Cast<Station>().ToList();

            RouteModel.AddRoute(newRout);
            this.Close();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            newRout = null;
            this.Close();
        }
    }
}
