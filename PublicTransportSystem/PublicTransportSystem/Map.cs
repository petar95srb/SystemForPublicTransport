﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoLayer.ModelViews;
using MongoLayer.Models;

namespace PublicTransportSystem
{

    public class Map
    {
        public Graphics render;
        public float wight;
        public float height;



        public Map(Graphics g,float wight=20,float height=20)
        {
            render = g;
            this.wight = wight;
            this.height = height;
        }

        public void  clearMap()
        {
            render.Clear(Color.White);
        }

        public void drawLines(RoutView rt,Color lineColor)
        {
            for(int i=0;i<rt.Stations.Count;i++)
            {
                render.FillEllipse(Brushes.Black,(float) rt.Stations[i].Lat - wight / 2,(float) rt.Stations[i].Lon - height / 2, wight, height);
                if(i>0)
                {
                    render.DrawLine(new Pen(lineColor, 10), (float)rt.Stations[i-1].Lat, (float)rt.Stations[i-1].Lon, (float)rt.Stations[i].Lat, (float)rt.Stations[i].Lon);
                }
                string lines = "";
                for(int j=0;j<rt.Stations[i].Lines.Count;j++)
                {
                    lines += rt.Stations[i].Lines[j].ToString();
                    if (j < rt.Stations[i].Lines.Count - 1)
                        lines += ",";
                }
                SizeF sz=render.MeasureString(lines, new Font(FontFamily.GenericMonospace, 10));
                render.DrawString(lines, new Font(FontFamily.GenericMonospace, 10), Brushes.Black, new PointF((float)rt.Stations[i].Lat - sz.Width / 2, (float)rt.Stations[i].Lon + height / 2 + 2));

            }
            //render.Flush();
        }
        public void drawmapLines(RoutView rt, Color lineColor)
        {
            for (int i = 0; i < rt.Stations.Count; i++)
            {
                //render.FillEllipse(Brushes.Black,(float) rt.Stations[i].Lat - wight / 2,(float) rt.Stations[i].Lon - height / 2, wight, height);
                if (i > 0)
                {
                    render.DrawLine(new Pen(lineColor, 10), (float)rt.Stations[i - 1].Lat, (float)rt.Stations[i - 1].Lon, (float)rt.Stations[i].Lat, (float)rt.Stations[i].Lon);
                }
                string lines = "";
                for (int j = 0; j < rt.Stations[i].Lines.Count; j++)
                {
                    lines += rt.Stations[i].Lines[j].ToString();
                    if (j < rt.Stations[i].Lines.Count - 1)
                        lines += ",";
                }
                SizeF sz = render.MeasureString(lines, new Font(FontFamily.GenericMonospace, 10));
                render.DrawString(lines, new Font(FontFamily.GenericMonospace, 10), Brushes.Black, new PointF((float)rt.Stations[i].Lat - sz.Width / 2, (float)rt.Stations[i].Lon + height / 2 + 2));

            }
            //render.Flush();
        }

        public void incriseStation(Station st)
        {
            render.FillEllipse(Brushes.Black, (float)st.Lat - wight, (float)st.Lon - height, (wight*2), (height*2));
        }
        public void Normakl(Station st)
        {
            render.FillEllipse(Brushes.Black, (float)st.Lat - wight/2, (float)st.Lon - height/2, (wight), (height));
        }

        public void DrawVihecals(List<RideView> vhs)
        {
            for (int i = 0; i < vhs.Count; i++)
            {
                render.FillEllipse(Brushes.Red, (float)vhs[i].CurrentStation.Lat - wight / 4, (float)vhs[i].CurrentStation.Lon - height / 4, wight/2, height/2);
               
            }
        }

        public void DrawStart(Station st)
        {
            render.DrawEllipse(Pens.Red, (float)(st.Lat - (wight * 1.2) / 2), (float)(st.Lon - (height * 1.2) / 2), (float)(wight * 1.2), (float)(height * 1.2));
        }

    }
}
