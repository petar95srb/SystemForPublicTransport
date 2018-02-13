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
        public IDictionary<string, object> DynamicFields { get; set; }

        public Classic() : base()
        {
            DynamicFields = new Dictionary<string, object>();
        }


    }
}
