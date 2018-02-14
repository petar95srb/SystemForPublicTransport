using MongoDB.Bson;
using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ModelViews
{
    public class RoutView
    {
        public ObjectId Id { get; set; }
        public int Line { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }//in minutes

        public Transport Transport { get; set; }
        public List<Station> Stations { get; set; }
        public List<Ride> Rides { get; set; }

        public IDictionary<string, object> DynamicFields { get; set; }

        //public RoutView()
        //{
        //    Stations = new List<Station>();
        //    Rides = new List<Ride>();
        //    DynamicFields = new Dictionary<string, object>();
        //}
    }
}
