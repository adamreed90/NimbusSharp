using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusSharp.Data
{
    [Function("authorize")]
    public class Authorize : NimbusFunction
    {
        [Property("amt")]
        public decimal Amount { get; set; }
        [Property("ord")]
        public string OrderId { get; set; }
        [Property("cUnum")]
        public string EmployeeId{ get; set; }
        [Property("cd")]
        public string Description { get; set; }
        [Property("ct")]
        public string EmployeeTeam { get; set; }
        [Property("en")]
        public string EmployeeName { get; set; }
        [Property("ip")]
        public string IpAddress { get; set; }
    }
}
