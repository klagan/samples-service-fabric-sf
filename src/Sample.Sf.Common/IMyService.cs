using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Sample.Sf.Common
{
    public interface IMyService : IService
    {
        Task<string> HelloWorldAsync();
    }
}
