namespace NimbusSharp.Data
{
    public class NimbusFunction
    {
        [Property("Cmn", true)]
        public string MerchantNumber { get; set; }
        /// <summary>
        /// This places the system into Test Mode, 0 = Live, 1 = Test.
        /// </summary>
        [Property("tst", true)]
        public bool Test { get; set; }
        /// <summary>
        /// This is the GPS latitude where the transaction is taking place.
        /// </summary>
        [Property("lat", true)]
        public double Lattitude { get; set; }
        /// <summary>
        /// This is the GPS longitude where the transaction is taking place.
        /// </summary>
        [Property("lon", true)]
        public double Longitude { get; set; }
        /// <summary>
        /// This tells the system if the card is swiped or keyed; (1=Swiped 2=Keyed)
        /// </summary>
        [Property("man", true)]
        public bool Manual { get; set; }
        
        //SWIPED
        [Property("td", false)]
        public string TrackData { get; set; }

        //KEYED
        [Property("co", true)]
        public string CardholderName { get; set; }
        [Property("can", true)]
        public string CardNumber { get; set; }
        [Property("exp", true)]
        public string CardExpiration { get; set; }
        [Property("cvv", true)]
        public string SecurityCode { get; set; }
        [Property("zc", true)]
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
        public Property(string value, bool required)
        {
            Name = value;
            Required = required;
        }
        public string Name { get; set; }
        public bool Required { get; set; }
    }

}
