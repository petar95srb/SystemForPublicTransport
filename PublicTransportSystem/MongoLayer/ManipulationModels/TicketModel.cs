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

        public static bool CheckTicket(ObjectId TicketId,ObjectId TransportId,DateTime date)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionTicket = db.GetCollection<Ticket>("Ticket");
            var collectionTransport = db.GetCollection<Ticket>("Transport");

            var Ticket = (from t in collectionTicket.AsQueryable<Ticket>() where t.Id == TicketId select t).FirstOrDefault();
            if (Ticket == null)
            {
                return false;
            }
            var Transport = (from t in collectionTransport.AsQueryable<Transport>() where t.Id == TransportId select t).FirstOrDefault();
            if (Transport == null)
            {
                return false;
            }
            if (Ticket.GetType() == typeof(TimeTicket))
            {
                if(((TimeTicket)Ticket).StartTime<date && ((TimeTicket)Ticket).EndTime > date)
                    {
                    return true;
                    }
            }
            if (Ticket.GetType() == typeof(Classic)){
                if (((Classic)Ticket).DynamicFields.ContainsKey(Transport.Type))
                {
                    if (((TransportCount)((Classic)Ticket).DynamicFields[Transport.Type]).NumOfRides > 0){
                        ((TransportCount)((Classic)Ticket).DynamicFields[Transport.Type]).NumOfRides = ((TransportCount)((Classic)Ticket).DynamicFields[Transport.Type]).NumOfRides - 1;
                        collectionTicket.Save(Ticket);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
