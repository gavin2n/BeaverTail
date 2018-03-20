using BeaverTail.API.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Database.Server;
using Swashbuckle.AspNetCore.Swagger;

namespace BeaverTail.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddSingleton(provider =>
            {
                NonAdminHttp.EnsureCanListenToWhenInNonAdminContext(8080);
                return new EmbeddableDocumentStore
                {
                    DataDirectory = "Data",
                    UseEmbeddedHttpServer = true
                }.Initialize();
            });
        

            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
