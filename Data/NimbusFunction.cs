using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusSharp.Data
{
    public class NimbusFunction
    {
        //tst - 0 = LIVE / 1 = TEST
        [Function("tst")]
        public bool Test { get; set; }
        //lat
        public double Lattitude { get; set; }
        //lon
        public double Longitude { get; set; }

        //man - 1 = SWIPED / 2 = KEYED
        public bool Manual { get; set; }


        //SWIPED
        //td - 
        public string TrackData { get; set; }

        //KEYED
        //co - 
        public string CardholderName { get; set; }
        //pan - 
        public string CardNumber { get; set; }
        //exp - 
        public string CardExpiration { get; set; }
        //cvv - 
        public string SecurityCode { get; set; }
        //zc - 
        public string ZipCode { get; set; }

    }

    public class Function : System.Attribute
    {

        public Function(string value)
        {
            Name = value;
        }

        public string Name { get; set; }
    }

    public class Property : System.Attribute
    {
        public Property(string value)
        {
            Name = value;
        }
        public string Name { get; set; }
    }

}
