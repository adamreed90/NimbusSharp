using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NimbusSharp.Data;

namespace NimbusSharp
{
    public class NimbusSharp
    {
        private string _merchantId;
        private string v2;

        public NimbusSharp(string merchantId, string v2)
        {
            _merchantId = merchantId;
            this.v2 = v2;
        }


        public async Task<NimbusResult> Execute(NimbusFunction function)
        {
            var functionString =
                function.GetType().GetTypeInfo().GetCustomAttributes(true).Cast<Function>().FirstOrDefault()?.Name;
            var propAttributes = function.GetType()
                .GetRuntimeProperties()
                .ToDictionary(p => p.Name, p => GetPropertyFunctionString(function, p));


            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Cmn", _merchantId),
                new KeyValuePair<string, string>("func", functionString)
            };
            foreach (var propAttribute in propAttributes)
            {
                try
                {
                    var property = propAttribute.Key;
                    var propString = propAttribute.Value;
                    var propInfo = function.GetType().GetRuntimeProperties().First(pi => pi.Name == property);
                    var propValue = propInfo.GetValue(function).ToString();
                    data.Add(new KeyValuePair<string, string>(propString, propValue));
                }
                catch
                {
                    // ignored
                }
            }

            var client = new HttpClient();
            var httpContent = new HttpRequestMessage(HttpMethod.Post, "http://ws.giftcardlive.com/testgate.php")
            {
                Content = new FormUrlEncodedContent(data)
            };
            var response = await client.SendAsync(httpContent);
            var result = await response.Content.ReadAsStringAsync();


            return null;
        }

        private static string GetPropertyFunctionString(NimbusFunction func, PropertyInfo property)
        {
            var properties = func.GetType().GetRuntimeProperties().ToDictionary(a => a.Name, a => a);
            var prop = properties.FirstOrDefault(f => f.Key == property.Name).Value;
            return prop.GetCustomAttributes(true).Cast<Property>().FirstOrDefault()?.Name;
        }
    }
}
