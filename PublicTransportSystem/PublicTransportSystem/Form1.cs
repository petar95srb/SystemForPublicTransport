using MongoLayer.ManipulationModels;
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
            //InitializationDataModel.InitCompany();
            //InitializationDataModel.InitTimeTable();
            //InitializationDataModel.JoinCompanyAndTimeTable();
            //InitializationDataModel.InitVehical();
            MessageBox.Show("Succes");
        }
    }
}
