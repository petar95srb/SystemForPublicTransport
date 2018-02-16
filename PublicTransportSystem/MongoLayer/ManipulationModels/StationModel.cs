using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ManipulationModels
{
    public static class StationModel
    {
        public static List<Station> GetAllStations()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionStation = db.GetCollection<Station>("Station");



            return (from s in collectionStation.AsQueryable<Station>() select s).ToList();

        }

        public static Station InsertStation(Station s)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionStation = db.GetCollection<Station>("Station");

            collectionStation.Insert(s);
            return s;
        }
        public static Station GetCurrentStation(ObjectId RideId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionRide = db.GetCollection<Ride>("Ride");

            var Ride = (from r in collectionRide.AsQueryable<Ride>() where r.Id == RideId select r).FirstOrDefault();
            if (Ride == null)
            {
                return null;
            }
            var Station = Ride.CurrentStation != null ? db.FetchDBRefAs<Station>(Ride.CurrentStation) : null;

            return Station;
        }

        public static List<Station> NotInRouteStations(string routId=null)
        {
            if (routId == null)
            {
                return GetAllStations();
            }
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionStation = db.GetCollection<Station>("Station");

            ObjectId RoutId = ObjectId.Parse(routId);

            var Rout = (from r in collectionRoute.AsQueryable<Route>() where r.Id == RoutId select r).FirstOrDefault();

            int line = Rout != null ? Rout.Line : 0;

            return (from s in collectionStation.AsQueryable<Station>() where !s.Lines.Contains(line) select s).ToList();
        }

        public static void RemoveStation(ObjectId StationId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");
            var collectionAlerts = db.GetCollection<Alerts>("Alerts");

            MongoDBRef Station = new MongoDBRef("Station", StationId);
            var Routes = (from r in collectionRoute.AsQueryable<Route>() where r.Stations.Contains(Station) select r).ToList();
            foreach(var r in Routes)
            {
                r.Stations.Remove(Station);
                collectionRoute.Save(r);
            }
            var Rides = (from r in collectionRide.AsQueryable<Ride>() where r.CurrentStation == Station select r).ToList();
            foreach(var r in Rides)
            {
                r.CurrentStation = null;
                collectionRide.Save(r);
            }
            var Alerts = (from a in collectionAlerts.AsQueryable<Alerts>() where a.Station == Station select a).ToList();
            foreach(var a in Alerts)
            {
                collectionAlerts.Remove(Query.EQ("_id",a.Id));
            }

            collectionStation.Remove(Query.EQ("_id",StationId));
        }
    }
}
