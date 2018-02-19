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
    public partial class Client : Form
    {

        public Ticket ticket=null;
        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Enabled)
            {
                if (string.IsNullOrEmpty(textBox1.Text)) return;

                var ts = TicketModel.GetTicket(new MongoDB.Bson.ObjectId(textBox1.Text));

                if (ts == null) return;

                textBox1.Enabled = false;
                button4.Text = "Log Out";

                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                textBox1.Enabled = true;
                
                button4.Text = "Check";

                button2.Enabled = false;
                button3.Enabled = false;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Status_Buy_Ticket by = new Status_Buy_Ticket(ticket);
            by.ShowDialog();

            if(by.ticket!=null)
            {
                if (ticket != null)
                    ticket = TicketModel.GetTicket(ticket.Id);
                else
                    ticket = by.ticket;

                textBox1.Text = ticket.Id.ToString();

                textBox1.Enabled = false;
                button4.Text = "Log Out";

                button2.Enabled = true;
                button3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Travel tv = new Travel(ticket);
            tv.ShowDialog();
        }
    }
}
