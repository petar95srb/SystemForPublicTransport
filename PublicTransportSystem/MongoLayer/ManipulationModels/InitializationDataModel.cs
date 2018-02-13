using MongoDB.Bson;
using MongoDB.Driver;
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
            tm.DynamicFields.Add("UpdateTime",new BsonDocument("UpdateTime", DateTime.Now.ToString()));
            collection.Insert(tm);
        }

    }
}
