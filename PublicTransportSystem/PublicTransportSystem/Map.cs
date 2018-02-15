using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoLayer.ModelViews;

namespace PublicTransportSystem
{

    public class Map
    {
        public Graphics render;

        public Map(Graphics g)
        {
            render = g;
        }

        public void  clearMap()
        {
            render.Clear(Color.White);
        }

        public void drawLines(RoutView rt,Color lineColor)
        {
            
          //  for(int i=0;i<)
        }





    }
}
