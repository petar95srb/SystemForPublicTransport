using MongoDB.Bson;
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

        public static List<Vehical> GetAllVehical(ObjectId TransportId)
        {

            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            MongoDBRef Transp = new MongoDBRef("Transport", TransportId);
            var collectionVehical = db.GetCollection<Vehical>("Vehical");

            return (from v in collectionVehical.AsQueryable<Vehical>() where v.Transport==Transp select v).ToList();
        }

        public static List<VehicalView> GetAllVehicalViews()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionVehical = db.GetCollection<Vehical>("Vehical");

            return (from v in collectionVehical.AsQueryable<Vehical>()
            select new VehicalView() {
                Id=v.Id,
                DynamicFields=v.DynamicFields,
                CurrentCond=v.CurrentCond,
                LastCheck=v.LastCheck,
                Ride=v.Ride!=null?db.FetchDBRefAs<Ride>(v.Ride):null,
                Transport=v.Transport!=null?db.FetchDBRefAs<Transport>(v.Transport):null,
                Type=v.Type

            }).ToList();
        }

        public static VehicalView GetVehicalView(ObjectId VehicalId)
        {
            
                var connectionString = "mongodb://localhost/?safe=true";
                var server = MongoServer.Create(connectionString);
                var db = server.GetDatabase("TransportSystem");


                var collectionVehical = db.GetCollection<Vehical>("Vehical");

                return (from v in collectionVehical.AsQueryable<Vehical>() where v.Id==VehicalId
                        select new VehicalView()
                        {
                            Id = v.Id,
                            DynamicFields = v.DynamicFields,
                            CurrentCond = v.CurrentCond,
                            LastCheck = v.LastCheck,
                            Ride = v.Ride != null ? db.FetchDBRefAs<Ride>(v.Ride) : null,
                            Transport = v.Transport != null ? db.FetchDBRefAs<Transport>(v.Transport) : null,
                            Type = v.Type

                        }).FirstOrDefault();
            
        }
    }
}
