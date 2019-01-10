using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Remoting.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Sample.Bll.Contract;
using Sample.Sf.Common;

namespace Sample.Sf.DummyService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    internal sealed class DummyService : StatelessService, IMyService
    {
        private readonly IDummyLogic _businessLogic;

        public DummyService(StatelessServiceContext context, IDummyLogic businessLogic)
            : base(context)
        {
            _businessLogic = businessLogic;
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return this.CreateServiceRemotingInstanceListeners();
        }

        public Task<string> HelloWorldAsync()
        {
            return Task.FromResult(_businessLogic.HellloWorld());
        }
    }
}
