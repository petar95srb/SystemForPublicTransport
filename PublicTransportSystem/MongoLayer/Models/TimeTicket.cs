using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.Models
{
    public class TimeTicket:Ticket
    {
        public int Duration { get; set; }//duration in hours
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Zone { get; set; }

    }
}
