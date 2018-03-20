using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeaverTail.API.DAL;

namespace BeaverTail.API.BLL
{
    public class LogConfigurationProvider : ILogConfigurationProvider
    {
        private readonly IConfigurationRepository _configurationRepository;

        public LogConfigurationProvider(IConfigurationRepository configurationRepository)
        {
            _configurationRepository = configurationRepository;
        }

        public Task<string> SaveNewLogConfiguration(LogConfiguration logConfiguration)
        {
            return _configurationRepository.StoreLogConfiguration(new LogConfigData()
            {
                Id = logConfiguration.ApplicationName,
                ServerList = logConfiguration.ServerList,
                RelativeLogPaths = logConfiguration.RelativeLogPaths
            });

            
        }

        public async Task<LogConfiguration> GetLogConfiguartionById(string Id)
        {
            var result = await _configurationRepository.GetLogConfiguration(Id);
            if (result == null)
            {
                return null;
            }
            return new LogConfiguration()
            {
                ApplicationName = result.Id,
                ServerList = result.ServerList,
                RelativeLogPaths = result.RelativeLogPaths
            };
        }

        public  List<LogConfiguration> GetLogConfigurations()
        {
            
            var result =  _configurationRepository.GetLogConfigurations();
            return result.Select(x => new LogConfiguration()
            {
                ApplicationName = x.Id,
                ServerList = x.ServerList,
                RelativeLogPaths = x.RelativeLogPaths
            }).ToList();
        }
    }
}
