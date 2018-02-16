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
    public partial class Vihecal : Form
    {
        List<VihecalType> types = new List<VihecalType>{ new VihecalType { name = "Bus", type = typeof(MongoLayer.Models.Bus) },
                                 {new VihecalType { name="Vagon",type=typeof(MongoLayer.Models.Vagon)}},
                                {new VihecalType { name="Voz",type=typeof(MongoLayer.Models.Locomotiva)}}
                                 };
        public Vihecal()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void Vihecal_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("ChoseType");
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.AddRange(types.ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedIndex==0)
            {
                // panel1.Visible = false;
                //panel2.Visible = false;
                // panel3.Visible = false;
                panel1.Hide();
                panel2.Hide();
                panel3.Hide();
            }

            if (comboBox1.SelectedIndex == 1)
            {
                panel1.Visible = true;
                // panel2.Visible = false;
                // panel3.Visible = false;
                panel2.Hide();
                panel3.Hide();
            }
            if (comboBox1.SelectedIndex ==2)
            {
               // panel1.Visible = false;
                panel1.Visible = true;
                // panel3.Visible = false;
                panel2.Hide();
                panel3.Hide();
            }
            if (comboBox1.SelectedIndex == 3)
            {
               // panel1.Visible = false;
               // panel2.Visible = false;
                panel3.Visible = true;
                panel2.Hide();
                panel1.Hide();
            }
           
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_VisibleChanged(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(VehicalModel.GetAllVagons().ToArray());
        }

        private void panel1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedIndex == 0)
            {
                return;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (AddBus())
                    this.Close();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                if (addVagon())
                    this.Close();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (addLocomotiv())
                    this.Close();
            }
        }

        private bool AddBus()
        {
            Bus bs = new Bus();
            bs.Type = (comboBox1.SelectedItem as VihecalType).name;
            bs.LastCheck = dateTimePicker1.Value;
            bs.CurrentCond = textBox1.Text;
            int psg;
            if (!int.TryParse(textBox2.Text, out psg)) return false;
            bs.NumOfPassengers = psg;
            var trs = TransportModel.GetTransport(bs.Type);

            bs.Transport = new MongoDB.Driver.MongoDBRef("Transport", trs.Id);

            VehicalModel.AddVehical(bs);
            return true;

        }
        private bool addVagon()
        {
            Vagon bs = new Vagon();
            bs.Type = (comboBox1.SelectedItem as VihecalType).name;
            bs.LastCheck = dateTimePicker1.Value;
            bs.CurrentCond = textBox1.Text;
            int psg;
            if (!int.TryParse(textBox2.Text, out psg)) return false;
            bs.NumOfPassengers = psg;
            var trs = TransportModel.GetTransport(bs.Type);

            bs.Transport = new MongoDB.Driver.MongoDBRef("Transport", trs.Id);

            VehicalModel.AddVehical(bs);
            return true;

        }
        private bool addLocomotiv()
        {
            Locomotiva bs = new Locomotiva();
            bs.Type = (comboBox1.SelectedItem as VihecalType).name;
            bs.LastCheck = dateTimePicker1.Value;
            bs.CurrentCond = textBox1.Text;
            int psg;
            if (!int.TryParse(textBox4.Text, out psg)) return false;
            bs.MaximumPulingCapacity = psg;

            var trs=TransportModel.GetTransport(bs.Type);

            bs.Transport = new MongoDB.Driver.MongoDBRef("Transport", trs.Id);
            var id=VehicalModel.AddVehical(bs);



            for(int i=0;i<listBox1.Items.Count;i++)
            {
                VehicalModel.AddVagon(id, (listBox1.Items[i] as Vagon).Id);
            }
            return true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == -1) return;

            var vg = listBox2.SelectedItem as Vagon;

            listBox1.Items.Add(vg);
            listBox2.Items.Remove(vg);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) return;

            var vg = listBox1.SelectedItem as Vagon;

            listBox2.Items.Add(vg);
            listBox1.Items.Remove(vg);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
