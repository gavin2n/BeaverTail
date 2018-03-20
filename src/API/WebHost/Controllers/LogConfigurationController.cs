using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeaverTail.API.Controllers
{
    [Route("api/logconfiguartion")]
    public class LogConfigurationController : Controller
    {
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
