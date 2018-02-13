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
    public class Ride
    {
        public ObjectId Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Late { get; set; }

        public MongoDBRef Rout { get; set; }
        public MongoDBRef CurrentStation { get; set; }
        public MongoDBRef Vehical { get; set; }

        [BsonExtraElements]
        public IDictionary<string, object> DynamicFields { get; set; }

        public Ride()
        {
            DynamicFields = new Dictionary<string, object>();
        }
    }
}
