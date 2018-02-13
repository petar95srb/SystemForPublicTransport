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

    public class TimeTable
    {
        public ObjectId Id { get; set; }

        public List<MongoDBRef> Rides { get; set; }

        [BsonExtraElements]
        public IDictionary<string,BsonDocument> DynamicFields { get; set; }

        public TimeTable()
        {
            Rides = new List<MongoDBRef>();
        }
    }
}
