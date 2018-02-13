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
    public class Alerts
    {
        public ObjectId Level { get; set; }
        public string  Description { get; set; }
        public MongoDBRef Station { get; set; }

        [BsonExtraElements]
        public List<BsonDocument> DynamicFields { get; set; }
    }
}
