using System;
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

            var address = new FabricServiceAddress("fabric:/Sample.Sf.Application/Sample.Sf.DummyService");

            var client = ServiceProxy.Create<IMyService>(address);

            var result = await client.HelloWorldAsync();

            Console.WriteLine($"Result: {result}");
            Console.ReadLine();
        }
    }
}
