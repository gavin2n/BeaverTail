using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeaverTail.API.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BeaverTail.API.Controllers
{
    [Route("/api/LogConfiguration/Servers")]
    public class ServerController : Controller
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ServerController(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        [Route(""), HttpGet]
        public IActionResult Get()
        {
            var serverList = _configurationRepository.GetLogConfigurations().SelectMany(x => x.ServerList).ToList();
            dynamic servers = serverList.Select(x=> new {ServerName = x, MoreInformation = $"/api/LogConfiguration/Servers/{x}" });
            return Ok(new {servers});
        }

        [Route("{serverName}"), HttpGet]
        public IActionResult GetByName(string serverName)
        {
            var appsOnServer = _configurationRepository.GetLogConfigurations()
                .Where(x=> x.ServerList.Contains(serverName))
                .Select(y=> new {applicationName = y.Id, extendedInformation = $"/api/LogConfiguration/applications/{y.Id}"}).ToList();
            return Ok(new {appsOnServer});
        }
    }
}
