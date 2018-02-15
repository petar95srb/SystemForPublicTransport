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
            transports = TransportModel.GetAllTransports();
            Transports.Items.AddRange(transports.ToArray());
           // updateMap();
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
            InitializationDataModel.InitTransportCountAndTimeTable();
            var r = RouteModel.GetAllRoutes();
         
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
    }
}
