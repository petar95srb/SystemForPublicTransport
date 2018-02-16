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
   public static class AlertsModel
    {
        public static List<AlertView> GetAlerts(string StationId = null)
        {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("TransportSystem");

            var collectionStation = db.GetCollection<Station>("Station");
            var collectionAlerts = db.GetCollection<Alerts>("Alerts");

            ObjectId AlId;
            MongoDBRef Station = null;
            if (StationId != null)
            {
                AlId = ObjectId.Parse(StationId);
                Station = new MongoDBRef("Station", AlId);


                var Alerts = collectionAlerts.AsQueryable<Alerts>().Where(p => p.Station ==Station).Select(s => new AlertView
                { 
                    Id = s.Id,
                    Description=s.Description,
                    DynamicFields=s.DynamicFields,
                    Level=s.Level,
                    Station = s.Station != null ? db.FetchDBRefAs<Station>(s.Station) : null,
           
                }).ToList();

                return Alerts;
            }
            else
            {

                var Alerts = collectionAlerts.AsQueryable<Alerts>().Select(s => new AlertView
                {
                    Id = s.Id,
                    Description = s.Description,
                    DynamicFields = s.DynamicFields,
                    Level = s.Level,
                    Station = s.Station != null ? db.FetchDBRefAs<Station>(s.Station) : null,

                }).ToList();

                return Alerts;
            }

        }
    }
}
