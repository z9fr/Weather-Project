using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherapp
{
    class weatherInfo
    {


        public class coord
        {
            public double ion { get; set; }
            public double lat { get; set; }
        } //cordinate class

        public class weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        } //weather class

        
        public class main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
            public double feels_like { get; set; }

        } //main class

        public class wind
        {
            public double speed { get; set; }
            public double gust { get; set; }
        } //wind class

        public class sys
        {
            public string country { get; set; }
            public double sunrise { get; set; }
            public double sunset { get; set; }
        } 


        public class root
        {
            public string name { get; set; }
            public int id { get; set; }
            public sys sys { get; set; }
            public double dt { get; set; }
            public wind wind { get; set; }
            public main main { get; set; }
            public List<weather> weather { get; set; }
            public coord coordinate { get; set; }

        }



    }
}
