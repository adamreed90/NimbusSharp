using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Net.Http;
using System.Threading.Tasks;
using NimbusSharp.Data;

namespace NimbusSharp
{
    public class NimbusSharp
    {
        private readonly string _merchantId;

        public NimbusSharp(string merchantId)
        {
            _merchantId = merchantId;
        }


        public async Task<string> Execute(NimbusFunction function)
        {
            function.MerchantNumber = _merchantId;

            CheckRequiredProperties(function);

            var functionString =
                function.GetType().GetTypeInfo().GetCustomAttributes(true).Cast<Function>().FirstOrDefault()?.Name;
            var propertyNames = function.GetType()
                .GetRuntimeProperties()
                .ToDictionary(p => p.Name, p => GetPropertyFunctionString(function, p));

            var data = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("func", functionString)
            };
            foreach (var propertyName in propertyNames)
            {
                try
                {
                    var property = propertyName.Key;
                    var propString = propertyName.Value;
                    var propInfo = function.GetType().GetRuntimeProperties().First(pi => pi.Name == property);
                    var propValue = propInfo.GetValue(function);

                    switch (property)
                    {
                        case "Test":
                            data.Add(new KeyValuePair<string, string>(propString, (bool) propValue ? "1" : "0"));
                            continue;
                        case "Manual":
                            data.Add(new KeyValuePair<string, string>(propString, (bool) propValue ? "2" : "1"));
                            continue;
                        case "CardholderName":
                            data.Add(new KeyValuePair<string, string>(propString, propValue.ToString()));
                            data.Add(new KeyValuePair<string, string>("cn", propValue.ToString()));
                            continue;
                    }
                    data.Add(new KeyValuePair<string, string>(propString, propValue.ToString()));
                }
                catch
                {
                    // ignored
                }
            }
            var client = new HttpClient();
            var httpContent = new HttpRequestMessage(HttpMethod.Post, "http://ws.nimbusprocessing.com/testgate.php ")
            {
                Content = new FormUrlEncodedContent(data)
            };
            var response = await client.SendAsync(httpContent);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }






        private static void CheckRequiredProperties(NimbusFunction function)
        {
            //Check for Required Data
            var properties = function.GetType().GetRuntimeProperties().ToDictionary(a => a.Name, a => a);
            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var property in properties)
            {
                var prop = properties.FirstOrDefault(f => f.Key == property.Key).Value;

                if (!prop.GetCustomAttributes(true).Cast<Property>().FirstOrDefault().Required) continue;

                var propInfo = function.GetType().GetRuntimeProperties().First(pi => pi.Name == property.Key);
                var propValue = propInfo.GetValue(function);

                if (propValue == null)
                {
                    throw new Exception(
                        $"[NimbusSharp] [Execute] The Property : {property.Key} is required, please populate this variable and try again.");
                }
            }
        }

        private static string GetPropertyFunctionString(NimbusFunction func, MemberInfo property)
        {
            var properties = func.GetType().GetRuntimeProperties().ToDictionary(a => a.Name, a => a);
            var prop = properties.FirstOrDefault(f => f.Key == property.Name).Value;
            return prop.GetCustomAttributes(true).Cast<Property>().FirstOrDefault()?.Name;
        }
    }
}
