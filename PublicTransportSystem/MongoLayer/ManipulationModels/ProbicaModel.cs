using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using MongoLayer.Models;

namespace MongoLayer.ManipulationModels
{
    public static class ProbicaModel
    {
      public static void InsertProbica()
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("Probica");

            var collection = db.GetCollection<Probica>("Lolcine");

            var p = new Probica { Lol = "wow" };

            collection.Insert(p);
        }
    }
}
