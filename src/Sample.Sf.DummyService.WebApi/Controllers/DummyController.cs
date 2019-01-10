using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Sf.Common;

namespace Sample.Sf.DummyService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase, IMyService
    {
        [HttpGet]
        public Task<string> HelloWorldAsync()
        {
            return Task.FromResult("Hello, from the other side of a webapi endpoint");
        }
    }
}