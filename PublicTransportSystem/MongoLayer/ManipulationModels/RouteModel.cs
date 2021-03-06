﻿using MongoDB.Bson;
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


                var routes = collectionRoute.AsQueryable<Route>().Where(p=>p.Transport == Transp).Select(s => new RoutView
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
            else
            {
                var routes = collectionRoute.AsQueryable<Route>().Select(s => new RoutView
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


        public static RoutView Rout(ObjectId routId,ObjectId StationId,int index)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");

            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");

            var Rout = (from r in collectionRoute.AsQueryable<Route>() where r.Id == routId select r).FirstOrDefault();
            if (Rout == null)
            {
                return null;
            }
            List<MongoDBRef> temp = new List<MongoDBRef>();
            int i = 0;
            foreach(var r in Rout.Stations)
            {
                if (i == index)
                {
                    temp.Add(new MongoDBRef("Station", StationId));
                    i = int.MinValue;
                }
                temp.Add(r);
                i++;
            }
            if (i > 0)
            {
                temp.Add(new MongoDBRef("Station", StationId));
            }
            Rout.Stations = temp;
            collectionRoute.Save(Rout);

            var station = (from s in collectionStation.AsQueryable<Station>() where s.Id == StationId select s).FirstOrDefault();

            if (station != null)
            {
                station.Lines.Add(Rout.Line);
                collectionStation.Save(station);
            }

            var route = collectionRoute.AsQueryable<Route>().Where(r=>r.Id==routId).Select(s => new RoutView
            {
                Duration = s.Duration,
                Id = s.Id,
                Line = s.Line,
                Price = s.Price,
                DynamicFields = s.DynamicFields,
                Stations = collectionStation.AsQueryable<Station>().ToList().Where(p => s.Stations.Contains(new MongoDBRef("Station", p.Id))).Select(p => p).ToList(),
                Transport = s.Transport != null ? db.FetchDBRefAs<Transport>(s.Transport) : null,
                Rides = collectionRide.AsQueryable<Ride>().ToList().Where(p => s.Rides.Contains(new MongoDBRef("Ride", p.Id))).Select(p => p).ToList(),
            }).FirstOrDefault();

            return route;
        }

        public static RoutView RemoveStation(ObjectId routId,ObjectId StationId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");

            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");

            var Rout = (from r in collectionRoute.AsQueryable<Route>() where r.Id == routId select r).FirstOrDefault();
            if (Rout == null)
            {
                return null;
            }
            Rout.Stations.Remove( new MongoDBRef("Station", StationId));
            collectionRoute.Save(Rout);

            var route = collectionRoute.AsQueryable<Route>().Where(r => r.Id == routId).Select(s => new RoutView
            {
                Duration = s.Duration,
                Id = s.Id,
                Line = s.Line,
                Price = s.Price,
                DynamicFields = s.DynamicFields,
                Stations = collectionStation.AsQueryable<Station>().ToList().Where(p => s.Stations.Contains(new MongoDBRef("Station", p.Id))).Select(p => p).ToList(),
                Transport = s.Transport != null ? db.FetchDBRefAs<Transport>(s.Transport) : null,
                Rides = collectionRide.AsQueryable<Ride>().ToList().Where(p => s.Rides.Contains(new MongoDBRef("Ride", p.Id))).Select(p => p).ToList(),
            }).FirstOrDefault();

            return route;
        }

        public static void AddRoute(RoutView rout)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");

            Route r = new Route()
            {
                Duration = rout.Duration,
                DynamicFields = rout.DynamicFields,
                Line = rout.Line,
                Price = rout.Price
            };
            foreach(var stat in rout.Stations)
            {
                r.Stations.Add(new MongoDBRef("Station", stat.Id));
            }

            r.Transport = new MongoDBRef("Transport", rout.Transport.Id);

            collectionRoute.Insert(r);

        }

        public static void DeleteRout(ObjectId routId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");

            var collectionRide = db.GetCollection<Ride>("Ride");

            var collectionStation = db.GetCollection<Station>("Station");
            var collectionTransport = db.GetCollection<Transport>("Transport");

            var Rout = (from r in collectionRoute.AsQueryable<Route>() where r.Id == routId select r).FirstOrDefault();
            if (Rout == null)
            {
                return;
            }
            var Stations=(from s in collectionStation.AsQueryable<Station>() where s.Lines.Contains(Rout.Line) select s).ToList();

            foreach(var s in Stations)
            {
                s.Lines.Remove(Rout.Line);
                collectionStation.Save(s);
            }

            MongoDBRef routRef = new MongoDBRef("Route", Rout.Id);

            //var query = Query.EQ("Rout",routRef.ToBsonDocument());
            //var update = MongoDB.Driver.Builders.Update.Set("Rout","");

            //collectionRide.Update(query, update);
            var Rides = (from r in collectionRide.AsQueryable<Ride>() where r.Rout == routRef select r).ToList();
            foreach(var r in Rides)
            {
                r.Rout = null;
                collectionRide.Save(r);

            }

            var Transports = (from t in collectionTransport.AsQueryable<Transport>() where t.Routs.Contains(routRef) select t).ToList();
            foreach(var t in Transports)
            {
                t.Routs.Remove(routRef);
                collectionTransport.Save(t);
            }

            collectionRoute.Remove(Query.EQ("_id", Rout.Id));
        }

        public static RoutView GetRout(ObjectId routId)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionRoute = db.GetCollection<Route>("Route");


            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");

            var route = collectionRoute.AsQueryable<Route>().Where(r => r.Id == routId).Select(s => new RoutView
            {
                Duration = s.Duration,
                Id = s.Id,
                Line = s.Line,
                Price = s.Price,
                DynamicFields = s.DynamicFields,
                Stations = collectionStation.AsQueryable<Station>().ToList().Where(p => s.Stations.Contains(new MongoDBRef("Station", p.Id))).Select(p => p).ToList(),
                Transport = s.Transport != null ? db.FetchDBRefAs<Transport>(s.Transport) : null,
                Rides = collectionRide.AsQueryable<Ride>().ToList().Where(p => s.Rides.Contains(new MongoDBRef("Ride", p.Id))).Select(p => p).ToList(),
            }).FirstOrDefault();

            return route;
        }
    }
}
