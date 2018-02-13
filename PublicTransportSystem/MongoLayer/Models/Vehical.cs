using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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

        [BsonExtraElements]
        public List<BsonDocument> DynamicFields { get; set; }
    }
}
