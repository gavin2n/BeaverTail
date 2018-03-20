using System.Collections.Generic;
using System.Threading.Tasks;
using BeaverTail.API.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BeaverTail.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IConfigurationRepository _configurationRepository;

        public ValuesController(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IList<FooConfig>> Get()
        {
            return await _configurationRepository.GetTopAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<FooConfig> GetAsync(string id)
        {
            return await _configurationRepository.GetFoo(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]string value)
        {
            await _configurationRepository.StoreFoo(new FooConfig
            {
                Foo = value
            });
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
