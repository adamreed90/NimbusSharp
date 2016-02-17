using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusSharp.Data
{
    [Function("void")]
    public class Void : NimbusFunction
    {
        [Property("transID", true)]
        public string TransactionId { get; set; }
        [Property("cd", false)]
        public string Description { get; set; }
        [Property("ct", false)]
        public string EmployeeTeam { get; set; }
        [Property("in", false)]
        public string InvoiceId { get; set; }



    }
}
