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
    public static class InitializationDataModel
    {
        public static void  InitCompany()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            //db.CreateCollection("preduzece");

            var collection = db.GetCollection<Company>("Company");

            Company comp = new Company { City = "Nis", Name = "JSP" };
            collection.Insert(comp);

        }

        public static void InitTimeTable()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            //db.CreateCollection("preduzece");

            var collection = db.GetCollection<TimeTable>("TimeTable");

            TimeTable tm = new TimeTable();
            tm.DynamicFields.Add("UpdateTime",DateTime.Now.ToString());
            tm.DynamicFields.Add("UniqueName", "PrvaRuta");
            collection.Insert(tm);
        }

        public static void JoinCompanyAndTimeTable()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

         
            var collectionT = db.GetCollection<TimeTable>("TimeTable");
            var collectionC = db.GetCollection<Company>("Company");

            var Comp = (from c in collectionC.AsQueryable<Company>() where c.City == "Nis" select c).FirstOrDefault();
            if (Comp == null)
            {
                return;
            }
            var TimeTables = collectionT.Find(Query.EQ("UniqueName","PrvaRuta")).FirstOrDefault();
            if (TimeTables == null)
            {
                return;
            }
            TimeTables.Company = new MongoDBRef("Comp", Comp.Id);
            Comp.TimeTable = new MongoDBRef("TimeTable", TimeTables.Id);
            collectionC.Save(Comp);
            collectionT.Save(TimeTables);


        }

        public static void InitVehical()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionV = db.GetCollection<TimeTable>("Vehical");

            Bus v = new Bus() { CurrentCond = "active", LastCheck = DateTime.Now, NumOfPassengers = 58 };
            collectionV.Insert(v);
            Locomotiva v1 = new Locomotiva() { CurrentCond = "active", LastCheck = DateTime.UtcNow, MaximumPulingCapacity = 290.65 };
        
            Vagon v2 = new Vagon() { CurrentCond = "active", LastCheck = DateTime.Now, NumOfPassengers = 30 };
            Vagon v3 = new Vagon() { CurrentCond = "error", LastCheck = DateTime.Now, NumOfPassengers = 40 };
            collectionV.Insert(v2);
            collectionV.Insert(v3);
            v1.Vagons.Add(new MongoDBRef("Vehical", v2.Id));
            v1.Vagons.Add(new MongoDBRef("Vehical", v3.Id));
            collectionV.Insert(v1);

            v2.Logomotiva = new MongoDBRef("Vehical", v1.Id);
            v3.Logomotiva = new MongoDBRef("Vehical", v1.Id);
            collectionV.Save(v2);
            collectionV.Save(v1);



        }

        public static void InitRoutes()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionCompany = db.GetCollection<Company>("Company");
            var collectionRoute = db.GetCollection<Route>("Route");
            var collectionStation = db.GetCollection<Station>("Station");
            var collectionRide = db.GetCollection<Ride>("Ride");
            var collectionTransport = db.GetCollection<Transport>("Transport");
            var collectionVehical = db.GetCollection<Vehical>("Vehical");

            var Company = (from c in collectionCompany.AsQueryable<Company>() select c).FirstOrDefault();
            Transport t = new Transport() { Type="Brod"};
            Station s1 = new Station() { Address = "bulevar", Lat = 54, Lon = 32, Lines = { 3, 4, 6 }, Name = "prva", Zone = 32 };
            Station s2 = new Station() { Address = "bulevar22", Lat = 14, Lon = 22, Lines = { 9, 43, 62 }, Name = "druga", Zone = 33 };
            Ride rid1 = new Ride() { StartTime = DateTime.Now.AddDays(+1), EndTime = DateTime.Now.AddDays(+2), Late = 0 };
            Ride rid2 = new Ride() { StartTime = DateTime.Now.AddDays(+3), EndTime = DateTime.Now.AddDays(+4), Late = 5 };
            Route rout1 = new Route() { Price = 120, Duration = 33, Line = 83 };
            Route rout2 = new Route() { Price = 180, Duration = 58, Line = 22 };

            if (Company != null)
            {
                t.Company = new MongoDBRef("Company", ObjectId.Parse("5a833b85de3456315450257c"));

            }
            collectionStation.Insert(s1);
            collectionStation.Insert(s2);
            collectionTransport.Insert(t);
            if (Company != null)
            {
                Company.Transports.Add(new MongoDBRef("Transport", t.Id));
                collectionCompany.Save(Company);
            }
           
            rid1.CurrentStation = new MongoDBRef("Station", s1.Id);
            rid2.CurrentStation = new MongoDBRef("Station", s2.Id);
           
            collectionRide.Insert(rid1);
            collectionRide.Insert(rid2);

            rout1.Rides.Add(new MongoDBRef("Ride", rid1.Id));
            rout1.Rides.Add(new MongoDBRef("Ride", rid2.Id));
            rout2.Rides.Add(new MongoDBRef("Ride", rid1.Id));
            rout2.Stations.Add(new MongoDBRef("Station", s1.Id));
            rout2.Stations.Add(new MongoDBRef("Station", s2.Id));
            rout1.Stations.Add(new MongoDBRef("Station", s2.Id));
            rout1.Transport = new MongoDBRef("Transport", t.Id);
           
            collectionRoute.Insert(rout1);
            collectionRoute.Insert(rout2);

            t.Routs.Add(new MongoDBRef("Route", rout1.Id));
            t.Routs.Add(new MongoDBRef("Route", rout2.Id));

            var Vehical = (from v in collectionVehical.AsQueryable() select v);
            foreach(var v in Vehical)
            {
                t.Vehicals.Add(new MongoDBRef("Vehical", v.Id));
            }

            collectionTransport.Save(t);


            rid1.Rout = new MongoDBRef("Route", rout1.Id);
            rid2.Rout = new MongoDBRef("Route", rout1.Id);

            collectionRide.Save(rid1);
            collectionRide.Save(rid2);

            

        }

        public static void InitAlert()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionAlerts = db.GetCollection<Alerts>("Alerts");
            var collectionStation = db.GetCollection<Station>("Station");

            var Stat = (from s in collectionStation.AsQueryable<Station>() where s.Address == "bulevar" select s).FirstOrDefault();
            
            Alerts al = new Alerts() { Description = "bulevar Station not in function", Level = 10 };
            collectionAlerts.Insert(al);
            if (Stat != null)
            {
                al.Station = new MongoDBRef("Station", Stat.Id);
                Stat.Alerts.Add(new MongoDBRef("Alerts", al.Id));
                collectionAlerts.Save(al);
                collectionStation.Save(Stat);
            }

        }


        public static void InitTikets()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionTicket = db.GetCollection<Ticket>("Ticket");



            //TransportCount tc1 = new TransportCount() { NumOfRides = 23, TransportType = "Bus" };
            //TransportCount tc2 = new TransportCount() { NumOfRides = 2, TransportType = "Metro" };
            //TransportCount tc3 = new TransportCount() { NumOfRides = 19, TransportType = "Brod" };

            Classic clasicTicket = new Classic() { Type = "classic" };
            clasicTicket.DynamicFields.Add("Bus",15);
            clasicTicket.DynamicFields.Add("Metro",21);
            clasicTicket.DynamicFields.Add("Brod",2);
            TimeTicket timeTicket = new TimeTicket() { Duration = 20, StartTime = DateTime.Now, EndTime = DateTime.Now.AddMonths(+2), Type = "time", Zone = 32 };

            collectionTicket.Insert(clasicTicket);
            collectionTicket.Insert(timeTicket);
        }

        public static void InitTimeTable1()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionTimeTable = db.GetCollection<TimeTable>("TimeTable");
            var collectionRide = db.GetCollection<Ride>("Ride");
            var collectionC = db.GetCollection<Company>("Company");

         
            TimeTable tt = new TimeTable();
            

            var Comp = (from c in collectionC.AsQueryable<Company>() select c).FirstOrDefault();
            if (Comp != null)
            {

                tt.Company = new MongoDBRef("Company", Comp.Id);
                
            }

            var rides = (from r in collectionRide.AsQueryable<Ride>() select r);
            foreach(var ride in rides)
            {
                tt.Rides.Add(new MongoDBRef("Ride", ride.Id));
            }

            collectionTimeTable.Insert(tt);

            if (Comp != null)
            {
                Comp.TimeTable = new MongoDBRef("TimeTable", tt.Id);
                collectionC.Save(Comp);
            }



        }

    }
}
