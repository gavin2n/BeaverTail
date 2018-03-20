using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace BeaverTail.API.Controllers
{
    [Route("api/logconfiguration")]
    public class LogConfigurationController : Controller
    {
        [Route(""), HttpGet]
        public object Get()
        {
            
            return new
            {
                Hello = "Hello"
            };
            return HttpStatusCode.OK;
        }
    }
}
