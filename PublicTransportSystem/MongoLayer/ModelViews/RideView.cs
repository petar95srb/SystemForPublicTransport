using MongoDB.Bson;
using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ModelViews
{
    public class RideView
    {
        public ObjectId Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Late { get; set; }

        public Route Rout { get; set; }
        public Station CurrentStation { get; set; }
        public Vehical Vehical { get; set; }

        public IDictionary<string, object> DynamicFields { get; set; }

        public RideView()
        {
            DynamicFields = new Dictionary<string, object>();
        }

        public override string ToString()
        {
            return Rout.Line.ToString() + " " + CurrentStation.Address + " "+StartTime.ToString("hh:mm:ss")+" " + Vehical;
        }
    }
}
