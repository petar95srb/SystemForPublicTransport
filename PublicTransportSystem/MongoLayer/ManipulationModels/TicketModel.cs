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
                    if ((int)((Classic)Ticket).DynamicFields[Transport.Type] > 0){
                        ((Classic)Ticket).DynamicFields[Transport.Type]= (int)((Classic)Ticket).DynamicFields[Transport.Type] - 1;
                        if ((int)((Classic)Ticket).DynamicFields[Transport.Type] == 0)
                        {
                            ((Classic)Ticket).DynamicFields.Remove(Transport.Type);
                        }
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

        public static void BuyClassicTicket(ObjectId TicketId, string Type, int numOfTicket)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionTicket = db.GetCollection<Ticket>("Ticket");
          

            var Ticket = (from t in collectionTicket.AsQueryable<Ticket>() where t.Id == TicketId select t).FirstOrDefault();
            if (Ticket == null)
            {
                return;
            }
          
         
            if (Ticket.GetType() == typeof(Classic))
            {
                if (((Classic)Ticket).DynamicFields.ContainsKey(Type))
                {
                    ((Classic)Ticket).DynamicFields[Type] = (int)((Classic)Ticket).DynamicFields[Type] + numOfTicket;

                }
                else
                {
                    ((Classic)Ticket).DynamicFields.Add(Type, numOfTicket);
                }
                collectionTicket.Save(Ticket);
            }
        }

       public static ObjectId BuyNewClassicTicket(Classic ticket)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");


            var collectionTicket = db.GetCollection<Ticket>("Ticket");
            collectionTicket.Insert(ticket);

            return ticket.Id;
        }

        public static ObjectId BuyNewTimeTicket(TimeTicket ticket)
        {
            
                var connectionString = "mongodb://localhost/?safe=true";
                var server = MongoServer.Create(connectionString);
                var db = server.GetDatabase("TransportSystem");


                var collectionTicket = db.GetCollection<Ticket>("Ticket");
                collectionTicket.Insert(ticket);

                 return ticket.Id;
        }
    }
}
