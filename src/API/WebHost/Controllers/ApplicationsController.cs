using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeaverTail.API.BLL;
using BeaverTail.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BeaverTail.API.Controllers
{
    [Route("api/LogConfiguration/Applications")]
    public class ApplicationsController : Controller
    {
        private readonly ILogConfigurationProvider _logConfigurationProvider;

        public ApplicationsController(ILogConfigurationProvider logConfigurationProvider)
        {
            _logConfigurationProvider = logConfigurationProvider;
        }

        [Route(""), HttpGet]
        public IActionResult GetAll()
        {

            var result = _logConfigurationProvider.GetLogConfigurations();
            return Ok(result);
        }

        [Route("{Id}"), HttpGet]
        public IActionResult Get(string Id)
        {
            return Ok(_logConfigurationProvider.GetLogConfiguartionById(Id));
        }
    }
}
