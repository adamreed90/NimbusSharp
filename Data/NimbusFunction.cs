using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusSharp.Data
{
    public class NimbusFunction
    {
        [Property("Cmn")]
        public string MerchantNumber { get; set; }
        /// <summary>
        /// This places the system into Test Mode, 0 = Live, 1 = Test.
        /// </summary>
        [Property("tst")]
        public bool Test { get; set; }
        /// <summary>
        /// This is the GPS latitude where the transaction is taking place.
        /// </summary>
        [Property("lat")]
        public double Lattitude { get; set; }
        /// <summary>
        /// This is the GPS longitude where the transaction is taking place.
        /// </summary>
        [Property("lon")]
        public double Longitude { get; set; }
        /// <summary>
        /// This tells the system if the card is swiped or keyed; (1=Swiped 2=Keyed)
        /// </summary>
        [Property("man")]
        public bool Manual { get; set; }
        
        //SWIPED
        [Property("td")]
        public string TrackData { get; set; }

        //KEYED
        [Property("co")]
        public string CardholderName { get; set; }
        [Property("can")]
        public string CardNumber { get; set; }
        [Property("exp")]
        public string CardExpiration { get; set; }
        [Property("cvv")]
        public string SecurityCode { get; set; }
        [Property("zc")]
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
