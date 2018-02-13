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

        [BsonExtraElements]
        public List<BsonDocument> DynamicFields { get; set; }

        public Transport()
        {
            Vehicals = new List<MongoDBRef>();
        }
    }
}
