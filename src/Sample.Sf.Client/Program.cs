using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Sample.Sf.Common;

namespace Sample.Sf.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult(); ;
        }

        static async Task MainAsync(string[] args)
        {
            Console.WriteLine("Press [RETURN] when ready to run test");
            Console.ReadLine();

            await FabricServiceCall();

            await WebApiCall();

            Console.ReadLine();
        }

        static async Task WebApiCall()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            
            var callTask = client.GetStringAsync("http://vmkamlagan:8209/api/dummy");

            var response = await callTask;

            Console.WriteLine($"WebApi Call Result: {response}");
        }

        static async Task FabricServiceCall()
        {
            var address = new FabricServiceAddress("fabric:/Sample.Sf.Application/Sample.Sf.DummyService");

            var client = ServiceProxy.Create<IMyService>(address);

            var result = await client.HelloWorldAsync();

            Console.WriteLine($"Fabric Service Call Result: {result}");
        }
    }
}
