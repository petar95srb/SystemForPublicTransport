using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.Models
{
    public class Station
    {
        public ObjectId Id { get; set; }
        public string  Name { get; set; }
        public string  Address { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public List<int> Lines { get; set; }
        public int Zone { get; set; }

        [BsonExtraElements]
        public List<BsonDocument> DynamicFields { get; set; }
        
        public Station()
        {
            Lines = new List<int>();
        }

    }
}
