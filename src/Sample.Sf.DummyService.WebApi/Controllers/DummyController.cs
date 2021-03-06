﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.Sf.Common;

namespace Sample.Sf.DummyService.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    /// <seealso cref="Sample.Sf.Common.IMyService" />
    /// <autogeneratedoc />
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase, IMyService
    {
        /// <summary>
        /// Helloes the world asynchronous.
        /// </summary>
        /// <returns code="200">a string message</returns>
        /// <returns code="201">a redirected string message</returns>
        /// <returns code="400">if errored</returns>
        /// <autogeneratedoc />
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public Task<string> HelloWorldAsync()
        {
            return Task.FromResult("Hello, from the other side of a webapi endpoint");
        }
    }
}