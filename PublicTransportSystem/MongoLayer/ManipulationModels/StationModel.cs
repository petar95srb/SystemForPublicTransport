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
    public static class StationModel
    {
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
    }
}
