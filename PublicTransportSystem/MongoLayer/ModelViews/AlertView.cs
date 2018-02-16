using MongoDB.Bson;
using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ModelViews
{
   public class AlertView
    {
        public ObjectId Id { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public Station Station { get; set; }

       
        public IDictionary<string, object> DynamicFields { get; set; }

        public AlertView()
        {
            DynamicFields = new Dictionary<string, object>();
        }
    }
}
