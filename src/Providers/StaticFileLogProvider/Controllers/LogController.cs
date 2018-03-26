using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using LazyCache;
using Microsoft.AspNetCore.Mvc;

namespace StaticFileLogProvider.Controllers
{
    [Route("api/logs")]
    public class LogController : Controller
    {

        private readonly IAppCache _cache;

        public LogController(IAppCache cache)
        {
            _cache = cache;
        }

        // GET api/values
        [HttpGet("{*path}")]
        public async Task<string> Get(string path)
        {
            try
            {
                return await _cache.GetOrAddAsync($"LogController.Get-{path}",() => ReadTextAsync(path),DateTimeOffset.Now.AddSeconds(10));
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        private async Task<string> ReadTextAsync(string filePath)
        {
            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 4096, useAsync: true))
            {
                StringBuilder sb = new StringBuilder();

                byte[] buffer = new byte[0x1000];
                int numRead;
                while ((numRead = await sourceStream.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string text = Encoding.UTF8.GetString(buffer, 0, numRead);
                    sb.Append(text);
                }

                return sb.ToString();
            }
        }
    }
}
