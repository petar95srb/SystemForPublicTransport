using MongoDB.Driver;
using MongoDB.Bson;
using MongoLayer.ManipulationModels;
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
using MongoLayer.ModelViews;

namespace PublicTransportSystem
{
    public partial class Form1 : Form
    {
        Map mapa;
        List<RoutView> routs;
        List<TransportView> transports;

        public Form1()
        {
            InitializeComponent();
            mapa = new PublicTransportSystem.Map(Map.CreateGraphics());
            updateComboBox();
           // updateMap();
        }
        private void updateComboBox()
        {
            transports = TransportModel.GetAllTransports();
            Transports.Items.Clear();
            Transports.Items.Add("Transports");
            Transports.SelectedIndex = 0;
            Transports.Items.AddRange(transports.ToArray());
        }
        private void Init_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");
            InitializationDataModel.InitCompany();
            InitializationDataModel.InitTimeTable();
            InitializationDataModel.JoinCompanyAndTimeTable();
            InitializationDataModel.InitVehical();
            InitializationDataModel.InitRoutes();
            InitializationDataModel.InitAlert();
            InitializationDataModel.InitTikets();
            InitializationDataModel.InitTimeTable1();
            var r = RouteModel.GetAllRoutes();
            updateComboBox();
            MessageBox.Show("Succes");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void updateMap()
        {
            TransportView test= Transports.SelectedItem as TransportView;
            if(test!=null)
            {
                routs = RouteModel.GetAllRoutes(test.Id.ToString());
            }
            else
            {
                routs = RouteModel.GetAllRoutes();
            }
            Random rand = new Random(Environment.TickCount);
           // mapa.clearMap();
            for(int i=0;i<routs.Count;i++)
            {
                Color b;
                byte[] color = new byte[3];
                rand.NextBytes(color);
                b= Color.FromArgb(color[0], color[1], color[2]);

                mapa.drawLines(routs[i], b);

               
            }


            //Map.Update();



        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //mapa.clearMap();
            //updateMap();
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            mapa.clearMap();
            updateMap();
        }

        private void Transports_SelectedIndexChanged(object sender, EventArgs e)
        {
            Map.Invalidate();
        }

        private void Map_MouseClick(object sender, MouseEventArgs e)
        {
            for(int i=0;i<routs.Count;i++)
            {
                for(int j=0;j<routs[i].Stations.Count;j++)
                {
                    Rectangle cs = new Rectangle((int)routs[i].Stations[j].Lat - 10,(int) routs[i].Stations[j].Lon - 10, 20, 20);
                    if(cs.Contains(e.Location))
                    {
                        ShowStation(routs[i].Stations[j]);
                        return;
                    }
                }
            }
        }

        private void ShowStation(Station st)
        {
            label1.Text = st.Address;
            label2.Text = st.Name;
            string lines = "";
            for (int j = 0; j < st.Lines.Count; j++)
            {
                lines += st.Lines[j].ToString();
                if (j <st.Lines.Count - 1)
                    lines += ",";
            }
            label3.Text = lines;
        }
    }
}
