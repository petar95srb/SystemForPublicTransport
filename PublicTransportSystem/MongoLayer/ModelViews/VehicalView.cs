using MongoDB.Bson;
using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ModelViews
{
    public class VehicalView
    {
        public ObjectId Id { get; set; }
        public DateTime LastCheck { get; set; }
        public string CurrentCond { get; set; }
        public string Type { get; set; }

        public Transport Transport { get; set; }
        public Ride Ride { get; set; }

  
        public IDictionary<string, object> DynamicFields { get; set; }

        public VehicalView()
        {
            DynamicFields = new Dictionary<string, object>();
        }
    }
}
