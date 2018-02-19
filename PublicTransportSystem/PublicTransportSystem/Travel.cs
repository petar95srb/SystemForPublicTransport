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
    public partial class Travel : Form
    {
        Ticket ticket;
        Map mapa;
        List<RoutView> routs;
        Station st = null;
        Station start = null;
        Station end = null;
        bool selectedst = false;
        List<VihecalType> types = new List<VihecalType>{ new VihecalType { name = "Bus", type = typeof(MongoLayer.Models.Bus) },
                                 {new VihecalType { name="Vagon",type=typeof(MongoLayer.Models.Vagon)}},
                                {new VihecalType { name="Voz",type=typeof(MongoLayer.Models.Locomotiva)}} };

        public Travel(Ticket ticket)
        {
            InitializeComponent();
            this.ticket = ticket;
            mapa = new PublicTransportSystem.Map(panel2.CreateGraphics());
            button1.Enabled = false;
            button2.Enabled = false;
        }
        private void updateMap()
        {
            var rd = comboBox2.SelectedItem as RoutView;
            if(rd==null)
            {
                var test = comboBox1.SelectedItem as VihecalType;
                // List<RoutView> routs;
                if (test != null)
                {
                    var ts = TransportModel.GetTransport(test.name);
                    routs = RouteModel.GetAllRoutes(ts.Id.ToString());
                }
                else
                {
                    routs = RouteModel.GetAllRoutes();
                }
                Random rand = new Random(Environment.TickCount);
                // mapa.clearMap();
                for (int i = 0; i < routs.Count; i++)
                {
                    Color b;
                    byte[] color = new byte[3];
                    rand.NextBytes(color);
                    b = Color.FromArgb(150, color[0], color[1], color[2]);

                    mapa.drawLines(routs[i], b);

                   // var rides = RideModel.GetAllRides(routs[i].Id);
                   // mapa.DrawVihecals(rides);
                }
                for (int i = 0; i < routs.Count; i++)
                {
                    var rides = RideModel.GetAllRides(routs[i].Id);
                    mapa.DrawVihecals(rides);
                }
            }
            else
            {
                Random rand = new Random(Environment.TickCount);
                Color b;
                byte[] color = new byte[3];
                rand.NextBytes(color);
                b = Color.FromArgb(150, color[0], color[1], color[2]);

                mapa.drawLines(rd, b);

                var rides = RideModel.GetAllRides(rd.Id);
                mapa.DrawVihecals(rides);
            }

            

        }
        private void Travel_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Transport");
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.AddRange(types.ToArray());
            comboBox2.Items.Add("Routs");
            comboBox2.SelectedIndex = 0;
            comboBox2.Enabled = false;
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var test = comboBox1.SelectedItem as VihecalType;
            if (test == null) return;

            var ts = TransportModel.GetTransport(test.name);

            comboBox2.Enabled = true;
            comboBox2.Items.AddRange(RouteModel.GetAllRoutes(ts.Id.ToString()).ToArray());

            mapa.clearMap();
            updateMap();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            mapa.clearMap();
            updateMap();
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < routs.Count; i++)
            {
                for (int j = 0; j < routs[i].Stations.Count; j++)
                {
                    Rectangle cs = new Rectangle((int)routs[i].Stations[j].Lat - 10, (int)routs[i].Stations[j].Lon - 10, 20, 20);
                    if (cs.Contains(e.Location))
                    {
                        ShowStation(routs[i].Stations[j]);
                        return;
                    }
                }
            }
        }
        private void ShowStation(Station st)
        {
            label5.Text = st.Address;
            label3.Text = st.Name;
            string lines = "";
            this.st = st;
            for (int j = 0; j < st.Lines.Count; j++)
            {
                lines += st.Lines[j].ToString();
                if (j < st.Lines.Count - 1)
                    lines += ",";
            }
            label6.Text = lines;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapa.clearMap();
            updateMap();
            var rd = comboBox2.SelectedItem as RoutView;
            if (rd == null) return;
            button1.Enabled = true;
           // rd.Duration


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!selectedst)
            {
                selectedst = true;
                mapa.DrawStart(st);
                start = st;

                var rd = comboBox2.SelectedItem as RoutView;
                var rides = RideModel.GetAllRides(rd.Id);

                int j = rd.Stations.IndexOf(start);
               


                string val = "";
                for(int i=0;i<rides.Count;i++)
                {
                    if(rides[i].CurrentStation==start)
                    {
                        val += ",0";
                        break;
                    }
                    int x = rd.Stations.IndexOf(rides[i].CurrentStation);
                    if (x == -1) x = 0;

                    int time = rd.Duration / rd.Stations.Count;
                    time *= i - x;
                    val+=","+time.ToString();
                }
                label4.Text = val;
                button2.Enabled = true;
            }
            else
            {
                if (st == start) return;
                selectedst = false;
               // mapa.DrawStart(st);
                end = st;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var test = comboBox1.SelectedItem as VihecalType;
            if (test == null) return;

            var ts = TransportModel.GetTransport(test.name);

            if(TicketModel.CheckTicket(ticket.Id, ts.Id, DateTime.Now))
            {
                MessageBox.Show("Succsess");
            }
            else
            {
                MessageBox.Show("kupi kartu!");
            }
        }
    }
}
