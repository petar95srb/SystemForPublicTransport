using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.Models
{
    public class Route
    {
        public ObjectId Id { get; set; }
        public int Line { get; set; }
        public float Price { get; set; }
        public int Duration { get; set; }//in minutes

        public MongoDBRef Transport { get; set; }
        public List<MongoDBRef> Stations { get; set; }
        public List<MongoDBRef> Rides { get; set; }

        [BsonExtraElements]
        public IDictionary<string, object> DynamicFields { get; set; }

        public Route()
        {
            Stations = new List<MongoDBRef>();
            Rides = new List<MongoDBRef>();
            DynamicFields = new Dictionary<string, object>();
        }
    }
}
