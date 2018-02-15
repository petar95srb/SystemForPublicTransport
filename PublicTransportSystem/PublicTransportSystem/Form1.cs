﻿using MongoDB.Bson;
using MongoDB.Driver;
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

namespace PublicTransportSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Init_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");
            //InitializationDataModel.InitCompany();
            //InitializationDataModel.InitTimeTable();
            //InitializationDataModel.JoinCompanyAndTimeTable();
            //InitializationDataModel.InitVehical();
          //  InitializationDataModel.InitRoutes();
            //InitializationDataModel.InitAlert();
            // InitializationDataModel.InitTikets();
            //  var r = RouteModel.GetAllRoutes();
           TicketModel.CheckTicket(ObjectId.Parse("5a85ded5de34561b8c293f7d"),ObjectId.Parse("5a85e2bfde3456237cb44e09"),DateTime.Now);
           // TicketModel.BuyClassicTicket(ObjectId.Parse("5a85ded5de34561b8c293f7d"), "Avion", 10);
         
             MessageBox.Show("Succes");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}
