using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NimbusSharp.Data;

namespace NimbusSharp
{
    public class NimbusSharp
    {
        private string v1;
        private string v2;

        public NimbusSharp(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        

        public async Task<NimbusResult> Execute(NimbusFunction function)
        {
            throw new NotImplementedException();
        }
    }
}
