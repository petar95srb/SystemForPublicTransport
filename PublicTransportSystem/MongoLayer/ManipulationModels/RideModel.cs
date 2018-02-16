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
    public static class RideModel
    {
        public static List<RideView> GetAllRides(ObjectId RoutId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");
            var collectionVehical = db.GetCollection<Vehical>("Vehical");


            MongoDBRef Rout = new MongoDBRef("Route", RoutId);

            var Rides = collectionRide.AsQueryable<Ride>().Where(p => p.Rout == Rout).Select(r => new RideView()
            {
                Id = r.Id,
                EndTime = r.EndTime,
                Late = r.Late,
                DynamicFields = r.DynamicFields,
                Rout = r.Rout != null ? db.FetchDBRefAs<Route>(r.Rout) : null,
                StartTime = r.StartTime,
                Vehical = r.Vehical != null ? db.FetchDBRefAs<Vehical>(r.Vehical) : null,
                CurrentStation = r.CurrentStation != null ? db.FetchDBRefAs<Station>(r.CurrentStation) : null,
            }).ToList();

            return Rides;
        }

        public static List<RideView> GetRides(ObjectId StationId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");
            var collectionVehical = db.GetCollection<Vehical>("Vehical");


            MongoDBRef Stat = new MongoDBRef("Station", StationId);

            var Rides = collectionRide.AsQueryable<Ride>().Where(p => p.CurrentStation == Stat).Select(r => new RideView()
            {
                Id = r.Id,
                EndTime = r.EndTime,
                Late = r.Late,
                DynamicFields = r.DynamicFields,
                Rout = r.Rout != null ? db.FetchDBRefAs<Route>(r.Rout) : null,
                StartTime = r.StartTime,
                Vehical = r.Vehical != null ? db.FetchDBRefAs<Vehical>(r.Vehical) : null,
                CurrentStation = r.CurrentStation != null ? db.FetchDBRefAs<Station>(r.CurrentStation) : null,
            }).ToList();

            return Rides;
        }


        public static void SetCurrentStation(ObjectId RaidId, string StationId=null)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");
            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");

            var Ride = (from r in collectionRide.AsQueryable<Ride>() where r.Id == RaidId select r).FirstOrDefault();
            if (Ride == null)
            {
                return;
            }
            if (StationId == null)
            {
                Ride.CurrentStation = null;
                collectionRide.Save(Ride);
                return;
            }
            ObjectId stat = ObjectId.Parse(StationId);
            var Station = (from s in collectionStation.AsQueryable<Station>() where s.Id == stat select s).FirstOrDefault();
            if (Station == null)
            {
                return;
            }
            Ride.CurrentStation = new MongoDBRef("Station", Station.Id);
            collectionRide.Save(Ride);

        }

        public static List<RideView> GetRoutRides(ObjectId RoutId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");
            var collectionVehical = db.GetCollection<Vehical>("Vehical");


            MongoDBRef Route = new MongoDBRef("Route",RoutId);

            var Rides = collectionRide.AsQueryable<Ride>().Where(p => p.Rout == Route).Select(r => new RideView()
            {
                Id = r.Id,
                EndTime = r.EndTime,
                Late = r.Late,
                DynamicFields = r.DynamicFields,
                Rout = r.Rout != null ? db.FetchDBRefAs<Route>(r.Rout) : null,
                StartTime = r.StartTime,
                Vehical = r.Vehical != null ? db.FetchDBRefAs<Vehical>(r.Vehical) : null,
                CurrentStation = r.CurrentStation != null ? db.FetchDBRefAs<Station>(r.CurrentStation) : null,
            }).ToList();

            return Rides;
        }


        public static void UpdateRide(RideView ride)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionRide = db.GetCollection<Ride>("Ride");

            var Ride = (from r in collectionRide.AsQueryable<Ride>() where r.Id == ride.Id select r).FirstOrDefault();
            if (Ride == null)
            {
                return;
            }
            Ride.CurrentStation = new MongoDBRef("Station", ride.CurrentStation.Id);
            Ride.DynamicFields = ride.DynamicFields;
            Ride.EndTime = ride.EndTime;
            Ride.Late = ride.Late;
            Ride.Rout = new MongoDBRef("Route", ride.Rout.Id);
            Ride.StartTime = ride.StartTime;
            Ride.Vehical = new MongoDBRef("Vehical", ride.Vehical.Id);

            collectionRide.Save(Ride);

        }

        public static void AddNewRide(RideView ride)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionRide = db.GetCollection<Ride>("Ride");

            Ride Ride = new Ride();

            Ride.CurrentStation = new MongoDBRef("Station", ride.CurrentStation.Id);
            Ride.DynamicFields = ride.DynamicFields;
            Ride.EndTime = ride.EndTime;
            Ride.Late = ride.Late;
            Ride.Rout = new MongoDBRef("Route", ride.Rout.Id);
            Ride.StartTime = ride.StartTime;
            Ride.Vehical = new MongoDBRef("Vehical", ride.Vehical.Id);

            collectionRide.Insert(Ride);
        }

        public static void RemoveRide(ObjectId rideId)
        {
            ObjectId iD = new ObjectId();
            
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionRide = db.GetCollection<Ride>("Ride");
            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionVehical = db.GetCollection<Vehical>("Vehical");

            MongoDBRef RideRef = new MongoDBRef("Ride", rideId);

            var query = Query.EQ("Ride", RideRef.ToBsonDocument());
            var update = MongoDB.Driver.Builders.Update.Set("Ride", iD);

            collectionVehical.Update(query, update);

            var Routs=(from r in collectionRoute.AsQueryable<Route>() where r.Rides.Contains(RideRef) select r).ToList();
            foreach (var r in Routs)
            {
                r.Rides.Remove(RideRef);
                collectionRoute.Save(r);
            }

            collectionRide.Remove(Query.EQ("_id",rideId));
        }
    }
}
