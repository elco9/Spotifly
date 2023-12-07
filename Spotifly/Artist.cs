using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Spotifly
{
    internal class Artist : Base
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime Birthday { get; set; }

        public int GetAge()
        {
            return 42;
        }

        public override string ToString()
        {

            return $"Name: {Name}\nCountry: {Country}\nDoB: {Birthday.ToString("dd-MM-yyyy")}\n";
        }
      
    }
}
