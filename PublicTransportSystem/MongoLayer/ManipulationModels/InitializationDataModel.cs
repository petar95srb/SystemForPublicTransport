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

    }
}
