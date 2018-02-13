using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.Models
{
    public class Classic:Ticket
    {
        //lista prevoza?
        [BsonExtraElements]
        public List<BsonDocument> DynamicFields { get; set; }


    }
}
