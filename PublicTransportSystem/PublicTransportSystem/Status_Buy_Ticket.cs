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
    public partial class Status_Buy_Ticket : Form
    {

        public Ticket ticket;


        public Status_Buy_Ticket(Ticket ts=null)
        {
            InitializeComponent();
            if(ts!=null)
            {
                ticket = ts;
                initData();
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
            }
            else
            {
                panel2.Visible = true;
                panel3.Visible = false;
            }
            
        }

        void initData()
        {
            var tcs = ticket as Classic;
            if(tcs!=null)
            {
                object val;
                if (tcs.DynamicFields.TryGetValue("Bus", out val))
                    label1.Text = "Bus:"+val.ToString();
                else
                    label1.Text = "Bus:0";

                if (tcs.DynamicFields.TryGetValue("Voz", out val))
                    label2.Text = "Bus:"+ val.ToString();
                else
                    label2.Text = "Bus:0";
                panel2.Visible = true;
                panel3.Visible = false;

                radioButton2.Checked = false;
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;

                panel2.Visible = false;
                panel3.Visible = true;

                textBox3.Text = (ticket as TimeTicket).Zone.ToString();
                dateTimePicker1.Value = (ticket as TimeTicket).StartTime;
                dateTimePicker2.Value = (ticket as TimeTicket).EndTime;
            }
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
              if(ticket == null)
              {
                    Classic ticket = new Classic();
                    int zone;
                    //if (!int.TryParse(textBox3.Text, out zone)) return;

                    //(ticket as Classic).DynamicFields.Add("Zona", zone);
                    bool by = false;
                    if (int.TryParse(textBox1.Text, out zone))
                    {
                        (ticket as Classic).DynamicFields.Add("Bus", zone);
                        by = true;
                    }

                    if (int.TryParse(textBox2.Text, out zone))
                    {
                        (ticket as Classic).DynamicFields.Add("Voz", zone);
                        by = true;
                    }
                    if (!by) return;
                    this.ticket= TicketModel.BuyNewClassicTicket(ticket as Classic);
              }
              else
              {
                    int zone;
                    if (int.TryParse(textBox1.Text, out zone))
                    {
                        TicketModel.BuyClassicTicket(ticket.Id, "Bus", zone);
                    }

                    if (int.TryParse(textBox2.Text, out zone))
                    {
                        TicketModel.BuyClassicTicket(ticket.Id, "Voz", zone);
                    }
                }
               
            }
            else
            {
                if (ticket == null)
                {
                    TimeTicket ticket = new TimeTicket();
                    int zone;
                    if (!int.TryParse(textBox3.Text, out zone)) return;

                    ticket.Zone = zone;
                    bool by = false;
                    ticket.StartTime= dateTimePicker1.Value;

                    ticket.EndTime = dateTimePicker2.Value;

                    var vs = ticket.EndTime.Subtract(ticket.StartTime);
                    if (vs.TotalHours == 0) return;

                    ticket.Duration = (int)vs.TotalHours;

                    this.ticket= TicketModel.BuyNewTimeTicket(ticket);
                }

            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ticket = null;
            this.Close();
        }
    }
}
