using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportSystem
{
    public class VihecalType
    {
        public string name { get; set; }
        public Type type { get; set; }

        public override string ToString()
        {
            return name;
        }
    }
}
