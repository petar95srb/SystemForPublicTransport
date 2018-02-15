using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoLayer.Models;
using MongoLayer.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ManipulationModels
{
    public static class TransportModel
    {
        public static List<TransportView> GetAllTransports()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionVehical = db.GetCollection<Vehical>("Vehical");
            var collectionTransport = db.GetCollection<Transport>("Transport");

            var transp =collectionTransport.AsQueryable<Transport>().Select(t => new TransportView()
            {
                Id=t.Id,
                Type=t.Type,
                Company = t.Company != null ? db.FetchDBRefAs<Company>(t.Company) : null,
                DynamicFields=t.DynamicFields,
                Routs=collectionRoute.AsQueryable<Route>().ToList().Where(p=>t.Routs.Contains(new MongoDBRef("Routs",p.Id))).ToList(),
                Vehicals=collectionVehical.AsQueryable<Vehical>().ToList().Where(v=>t.Vehicals.Contains(new MongoDBRef("Vehicals",v.Id))).ToList(),

            }).ToList();

            return transp;
        }
    }
}
