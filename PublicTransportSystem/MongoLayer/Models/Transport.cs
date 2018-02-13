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
    public class Transport
    {
        public ObjectId Id { get; set; }

        public List<MongoDBRef> Vehicals { get; set; }
        public List<MongoDBRef> Routs { get; set; }

        public MongoDBRef Company { get; set; }

        [BsonExtraElements]
        public IDictionary<string, object> DynamicFields { get; set; }

        public Transport()
        {
            Vehicals = new List<MongoDBRef>();
            Routs = new List<MongoDBRef>();
            DynamicFields = new Dictionary<string, object>();
        }
    }
}
