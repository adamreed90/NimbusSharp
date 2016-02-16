using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusSharp.Data
{
    [Function("authorize")]
    class Authorize : NimbusFunction
    {
        [Property("amt")]
        public decimal Amount { get; set; }
        [Property("ord")]
        public string OrderId { get; set; }
        [Property("cUnum")]
        public string EmployeeId{ get; set; }

    }
}
