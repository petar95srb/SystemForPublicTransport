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

        
               MongoDBRef Rout = new MongoDBRef("Route",RoutId);

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


            MongoDBRef Stat = new MongoDBRef("Station",StationId);

            var Rides = collectionRide.AsQueryable<Ride>().Where(p => p.CurrentStation ==Stat).Select(r => new RideView()
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
    }
}
