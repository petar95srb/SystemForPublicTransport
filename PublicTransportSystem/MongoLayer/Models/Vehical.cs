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
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Vagon), typeof(Locomotiva),typeof(Bus))]
    public abstract class Vehical
    {
        public ObjectId Id { get; set; }
        public DateTime LastCheck { get; set; }
        public string CurrentCond { get; set; }
        public string Type { get; set; }

        public MongoDBRef Transport { get; set; }
        public MongoDBRef Ride { get; set; }

        [BsonExtraElements]
        public IDictionary<string, object> DynamicFields { get; set; }

        public Vehical()
        {
            DynamicFields = new Dictionary<string, object>();
        }
    }
}
