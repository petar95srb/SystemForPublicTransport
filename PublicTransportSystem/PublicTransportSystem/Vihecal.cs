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
    public partial class Vihecal : Form
    {
        List<VihecalType> types = new List<VihecalType>{ new VihecalType { name = "Bus", type = typeof(MongoLayer.Models.Bus) },
                                {new VihecalType { name="Voz",type=typeof(MongoLayer.Models.Locomotiva)}},
                                 {new VihecalType { name="Vagon",type=typeof(MongoLayer.Models.Vagon)}}};
        public Vihecal()
        {
            InitializeComponent();
        }

        private void Vihecal_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("ChoseType");
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.AddRange(types.ToArray());
        }
    }
}
