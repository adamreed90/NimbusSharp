using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusSharp.Data
{
    [Function("verify")]
    public class Verify : NimbusFunction
    {
        [Property("cUnum")]
        public string EmployeeID { get; set; }

    }
}
