using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoLayer.ModelViews
{
    class RideViewTimeTable
    {
        public string Line { get; set; }
        public string TransportType { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string CurrentStation { get; set; }
    }
}
