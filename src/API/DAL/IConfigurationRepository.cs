using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeaverTail.API.DAL
{
    public interface IConfigurationRepository
    {
        Task<FooConfig> GetFoo(string Id);
        Task<string> StoreFoo(FooConfig foo);
        Task<IList<FooConfig>> GetTopAsync();

        Task<LogConfigData> GetLogConfiguration(string Id);

        Task<string> StoreLogConfiguration(LogConfigData logConfig);

        List<LogConfigData> GetLogConfigurations();
    }
}