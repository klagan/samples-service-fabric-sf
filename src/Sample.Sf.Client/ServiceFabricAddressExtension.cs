using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Remoting.Client;

namespace Sample.Sf.Client
{
    public static class ServiceFabricAddressExtension
    {
        public static Task<bool> IsOnline<T>(this FabricServiceAddress address)
        where T : IService
        {
            try
            {
                ServiceProxy.Create<T>(address);

                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);

                return Task.FromResult(false);
            }
        }
    }
}
