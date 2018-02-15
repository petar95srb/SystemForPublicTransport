using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.Models
{
    public class TransportCount
    {
      
        public string TransportType { get; set; }
        public int NumOfRides { get; set; }

    }
}
