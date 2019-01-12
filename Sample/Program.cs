/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OAuth.ClientCredentialsFlow.Models;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await Authenticate();
            }).GetAwaiter().GetResult();
        }

        static async Task Authenticate()
        {
            var authInfo = new AuthInfo();
            authInfo.Scope = Constants.Scope;
            authInfo.ClientId = Constants.ClientId;
            authInfo.ClientSecret = Constants.ClientSecret;

            ClientCredentialsFlow clientCredentialsFlow = new ClientCredentialsFlow(Constants.Authority, authInfo);
            var result = await clientCredentialsFlow.Authenticate();

            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.ReadLine();
        }
    }
}
