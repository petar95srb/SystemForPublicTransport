using MongoDB.Bson;
using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ModelViews
{
    public class TransportView
    {
        public ObjectId Id { get; set; }

        public List<Vehical> Vehicals { get; set; }
        public List<Route> Routs { get; set; }

        public Company Company { get; set; }

        public IDictionary<string, object> DynamicFields { get; set; }

        public TransportView()
        {
            Vehicals = new List<Vehical>();
            Routs = new List<Route>();
            DynamicFields = new Dictionary<string, object>();
        }
    }
}
