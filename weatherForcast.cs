using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherapp
{
    public class weatherForcast
    {
        public List<daily> daily { get; set; } //forcast list 
    }

    public class temp
    {
        public double day { get; set; }
        public double min { get; set;  }
        public double max { get; set; }

    }


    public class weather
    {
        public int id { get; set; } // wether id ( to add the image ) 
        public string main { get; set; } //weather condition 
        public string description { get; set; }
    }

    public class daily
    {
        public double dt { get; set; } // days in ms
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double wind_speed { get; set; } //wind speed
        public temp temp { get; set; }
        public List<weather> weather { get; set; }
    }

}
