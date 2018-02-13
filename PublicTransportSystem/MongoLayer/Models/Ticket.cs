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
    [BsonKnownTypes(typeof(Classic), typeof(TimeTicket))]
    public class Ticket
    {
        public ObjectId Id { get; set; }
        public string Type { get; set; }

    }
}
