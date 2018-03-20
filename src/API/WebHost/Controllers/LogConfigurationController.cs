using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BeaverTail.API.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Raven.Abstractions.Connection;

namespace BeaverTail.API.Controllers
{
    [Route("api/logconfiguration")]
    public class LogConfigurationController : Controller
    {
        private readonly ILogConfigurationProvider _logConfigurationProvider;
        public LogConfigurationController(ILogConfigurationProvider logConfigurationProvider)
        {
            _logConfigurationProvider = logConfigurationProvider;
        }
        [Route(""), HttpGet]
        public object Get()
        {

            return new
            {
                ApplicationName = "",
                Servers = new
                {

                },
                RelativeLogPaths = new
                {
                }
            };
            return HttpStatusCode.OK;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Post(LogConfiguration logConfiguration)
        {
            var exists = await _logConfigurationProvider.GetLogConfiguartionById(logConfiguration.ApplicationName);
            if (exists != null)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            var created = await _logConfigurationProvider.SaveNewLogConfiguration(logConfiguration);
            if (created == null) return StatusCode(StatusCodes.Status500InternalServerError);
            var config = await _logConfigurationProvider.GetLogConfiguartionById(created);
           
            return Created($"/api/LogConfiguration/applications/{config.ApplicationName}",created);
        }
    }
}
