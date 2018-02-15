using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ManipulationModels
{
   public static class VehicalModel
    {
        public static List<Vehical> GetAllVehical()
        {

            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionVehical = db.GetCollection<Vehical>("Vehical");

            return (from v in collectionVehical.AsQueryable<Vehical>() select v).ToList();
        }
    }
}
