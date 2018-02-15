using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ManipulationModels
{
    public static class TicketModel
    {
        public static Ticket GetTicket(ObjectId Id)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionTicket = db.GetCollection<Ticket>("Ticket");

            return (from t in collectionTicket.AsQueryable<Ticket>() where t.Id == Id select t).FirstOrDefault();
        }
    }
}
