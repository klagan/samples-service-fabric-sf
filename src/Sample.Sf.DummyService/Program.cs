using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.ServiceFabric.Services.Communication;
using Microsoft.ServiceFabric.Services.Runtime;
using Sample.Bll;
using Sample.Bll.Contract;

namespace Sample.Sf.DummyService
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            var services = new ServiceCollection();
            services.AddSingleton(services.BuildServiceProvider());

            try
            {
                ServiceRuntime.RegisterServiceAsync("Sample.Sf.DummyServiceType",
                    context =>
                    {
                        services.AddSingleton(context);
                        services.AddScoped<DummyService>();
                        services.AddTransient<IDummyLogic, DummyLogic>();

                        return services
                            .BuildServiceProvider()
                            .GetService<DummyService>();
                    })
                    .GetAwaiter()
                    .GetResult();

                ServiceEventSource.Current.ServiceTypeRegistered(Process.GetCurrentProcess().Id, typeof(DummyService).Name);

                // Prevents this host process from terminating so services keep running.
                Thread.Sleep(Timeout.Infinite);
            }
            catch (Exception e)
            {
                ServiceEventSource.Current.ServiceHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
