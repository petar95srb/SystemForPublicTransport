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
    public static class RouteModel
    {
        public static List<RoutView> GetAllRoutes(string TransportId = null)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");
            var collectionTransport = db.GetCollection<Transport>("Transport");

            ObjectId TrId;
            MongoDBRef Transp = null;
            if (TransportId != null)
            {
                TrId = ObjectId.Parse(TransportId);
                Transp = new MongoDBRef("Transport", TrId);
            }

            var routes = collectionRoute.AsQueryable<Route>().Where(p => (TransportId != null && p.Transport != null) ? p.Transport == Transp : true == true).Select(s => new RoutView
            {
                Duration = s.Duration,
                Id = s.Id,
                Line = s.Line,
                Price = s.Price,
                DynamicFields = s.DynamicFields,
                Stations = collectionStation.AsQueryable<Station>().ToList().Where(p => s.Stations.Contains(new MongoDBRef("Station", p.Id))).Select(p => p).ToList(),
                Transport = s.Transport != null ? db.FetchDBRefAs<Transport>(s.Transport) : null,
                Rides = collectionRide.AsQueryable<Ride>().ToList().Where(p => s.Rides.Contains(new MongoDBRef("Ride", p.Id))).Select(p => p).ToList(),
            }).ToList();



            return routes;

        }
    }
}
