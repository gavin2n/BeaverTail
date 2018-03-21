using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeaverTail.API.BLL
{
    public interface ILogConfigurationProvider
    {
        Task<string> SaveNewLogConfiguration(LogConfiguration logConfiguration);

        Task<LogConfiguration> GetLogConfiguartionById(string Id);

        List<LogConfigurationOverview> GetLogConfigurations();
    }
}
