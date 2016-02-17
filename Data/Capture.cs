using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusSharp.Data
{
    [Function("capture")]
    public class Capture : NimbusFunction
    {
        [Property("transID", true)]
        public string TransactionId { get; set; }
        [Property("amt", true)]
        public decimal Amount { get; set; }

    }
}
