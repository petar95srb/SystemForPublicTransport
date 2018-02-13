using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.Models
{
    public class Vagon:Vehical
    {
        public int NumOfPassengers { get; set; }
        public MongoDBRef Logomotiva { get; set; }

    }
}
