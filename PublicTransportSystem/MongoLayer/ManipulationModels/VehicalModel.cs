using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
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

       public static List<Vagon> GetAllVagons()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionVehical = db.GetCollection<Vehical>("Vehical");

            MongoDBRef lok = new MongoDBRef("Vehical", "");

            var Vagons = (from v in collectionVehical.AsQueryable<Vagon>() where v.Logomotiva == null || v.Logomotiva == lok select v).ToList();
            return Vagons;
        }

        public static Locomotiva AddVagon(ObjectId lokId,ObjectId vagonId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionVehical = db.GetCollection<Vehical>("Vehical");

            var Lokom = (from l in collectionVehical.AsQueryable<Locomotiva>() where l.Id == lokId select l).FirstOrDefault();
            if (Lokom == null)
            {
                return null;
            }
            var Vagon = (from v in collectionVehical.AsQueryable<Vagon>() where v.Id == vagonId select v).FirstOrDefault();
            if (Vagon == null)
            {
                return null;
            }
            Lokom.Vagons.Add(new MongoDBRef("Vehical", Vagon.Id));
            Vagon.Logomotiva = new MongoDBRef("Vehical", Lokom.Id);
            collectionVehical.Save(Lokom);
            collectionVehical.Save(Vagon);
            return Lokom;
        }

        public static void DeleteLokomotive(ObjectId lokId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionVehical = db.GetCollection<Vehical>("Vehical");
            MongoDBRef LokRef = new MongoDBRef("Vehical", lokId);
            var Vagons = (from v in collectionVehical.AsQueryable<Vagon>() where v.Logomotiva == LokRef select v).ToList();
            foreach(var v in Vagons)
            {
                v.Logomotiva = null;
                collectionVehical.Save(v);
            }
            collectionVehical.Remove(Query.EQ("_id",lokId));


        }

        public static void RemoveVagons(ObjectId lokId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionVehical = db.GetCollection<Vehical>("Vehical");
            var Lokom = (from l in collectionVehical.AsQueryable<Locomotiva>() where l.Id == lokId select l).FirstOrDefault();
            if (Lokom == null)
            {
                return;
            }
            MongoDBRef LokRef = new MongoDBRef("Vehical", lokId);
            var Vagons = (from v in collectionVehical.AsQueryable<Vagon>() where v.Logomotiva == LokRef select v).ToList();
            foreach (var v in Vagons)
            {
                v.Logomotiva = null;
                Lokom.Vagons.Remove(new MongoDBRef("Vehical", v.Id));
                collectionVehical.Save(v);
            }
            collectionVehical.Save(Lokom);
        }

        public static List<Vagon> GetAllVagons(ObjectId lokId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionVehical = db.GetCollection<Vehical>("Vehical");
           
            MongoDBRef LokRef = new MongoDBRef("Vehical", lokId);
            var Vagons = (from v in collectionVehical.AsQueryable<Vagon>() where v.Logomotiva == LokRef select v).ToList();

            return Vagons;
        }

        public static ObjectId AddVehical(Vehical v)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionVehical = db.GetCollection<Vehical>("Vehical");

            collectionVehical.Insert(v);

            return v.Id;

        }

        public static void RemoveVehical(ObjectId VehicalId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionVehical = db.GetCollection<Vehical>("Vehical");
            var collectionTransport = db.GetCollection<Transport>("Transport");
            var Vehical = (from v in collectionVehical.AsQueryable<Vehical>() where v.Id == VehicalId select v).FirstOrDefault();
            if (Vehical == null)
            {
                return;
            }
            var collectionRide = db.GetCollection<Ride>("Ride");

            MongoDBRef vehical = new MongoDBRef("Vehical", Vehical.Id);
            var Ride = (from r in collectionRide.AsQueryable<Ride>() where r.Vehical == vehical select r).FirstOrDefault();
            if (Ride != null)
            {
                RideModel.RemoveRide(Ride.Id);
            }
            var Transports = (from t in collectionTransport.AsQueryable<Transport>() where t.Vehicals.Contains(vehical) select t).ToList();
            foreach(var t in Transports)
            {
                t.Vehicals.Remove(vehical);
                collectionTransport.Save(t);
            }
            if (Vehical.GetType() == typeof(Locomotiva))
            {
                DeleteLokomotive(Vehical.Id);
            }
            else
            {
                collectionVehical.Remove(Query.EQ("_id",Vehical.Id));
            }
            
         
        }
    }
}
