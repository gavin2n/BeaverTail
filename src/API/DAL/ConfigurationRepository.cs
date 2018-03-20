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
