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
    public class Locomotiva:Vehical
    {
        public double MaximumPulingCapacity { get; set; }

        public List<MongoDBRef> Vagons { get; set; }
        
        public Locomotiva():base()
        {
            Vagons = new List<MongoDBRef>();
        }
    }
}
