using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raven.Client;
using Raven.Client.Linq;

namespace BeaverTail.API.DAL
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IDocumentStore _store;

        public ConfigurationRepository(IDocumentStore store)
        {
            _store = store;
        }

        public async Task<FooConfig> GetFoo(string Id)
        {
            using (var session = _store.OpenAsyncSession())
            {
                var foo = await session.LoadAsync<FooConfig>(Id);
                return foo;
            }
        }

        public async Task<LogConfigData> GetLogConfiguration(string Id)
        {
            using (var session = _store.OpenAsyncSession())
            {
                var config = await session.LoadAsync<LogConfigData>(Id);
                return config;
            }
        }
        public async Task<string> StoreLogConfiguration(LogConfigData logConfig)
        {
            using (var session = _store.OpenAsyncSession())
            {
                await session.StoreAsync(logConfig);

                await session.SaveChangesAsync();

                return logConfig.Id;
            }
        }

        public  List<LogConfigData> GetLogConfigurations()
        {
            using (var session = _store.OpenSession())
            {
                var config = session.Query<LogConfigData>();
                return config.ToList();
            }
        }

        public List<string> GetServerListFromConfig()
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> StoreFoo(FooConfig foo)
        {
            using (var session = _store.OpenAsyncSession())
            {
                await session.StoreAsync(foo);

                await session.SaveChangesAsync();

                return foo.Id;
            }
        }

        public async Task<IList<FooConfig>> GetTopAsync()
        {
            using (var session = _store.OpenAsyncSession())
            {
                return await session.Query<FooConfig>().ToListAsync();
            }
        }
    }
}
