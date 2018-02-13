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

    public class Company
    {
        public ObjectId Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }

        public List<MongoDBRef> Transports { get; set; }
        public MongoDBRef TimeTable { get; set; }

        [BsonExtraElements]
        public IDictionary<string,object> DynamicFields { get; set; }


        public Company()
        {
            DynamicFields = new Dictionary<string, object>();
            Transports = new List<MongoDBRef>();
        }
    }
}
