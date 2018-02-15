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
    public partial class Admin2 : Form
    {
        List<RoutView> routs;

        public Admin2()
        {
            InitializeComponent();
            routs = RouteModel.GetAllRoutes();
            dataGridView1.DataSource = routs;
        }

        private void Admin2_Load(object sender, EventArgs e)
        {

        }
    }
}
