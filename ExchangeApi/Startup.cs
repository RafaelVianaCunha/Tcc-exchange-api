using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using ExchangeApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ExchangeApi.Domain.Repositories;
using ExchangeApi.Infrastructure.Repositories.Writers;
using ExchangeApi.Application.Services;
using SimpleInjector.Lifestyles;

namespace ExchangeApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        Container container = new SimpleInjector.Container();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSimpleInjector(container, options => {
                options
                    .AddAspNetCore()
                    .AddControllerActivation()
                    .AddViewComponentActivation();
            });

            InitializeContainer();
        }

        private void InitializeContainer()
        {
            container.Register<ExchangeDbContext>(() => {
                var connectionString = Configuration.GetSection("ExchangeDb").Value.ToString();
            
                var optionsBuilder = new DbContextOptionsBuilder<ExchangeDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new ExchangeDbContext(optionsBuilder.Options);
            }, Lifestyle.Scoped);

            container.Register<IExchangeWriter, ExchangeWriter>();
            container.Register<IExchangeCredentialReader, ExchangeCredentialReader>();
        
            container.RegisterDecorator<IExchangeCredentialCreation, ExchangeCreationWithAlreadyExists>();
            container.Register<IExchangeCredentialCreation, ExchangeCredentialCreation>();
            container.Register<IExchangeDelete, ExchangeDelete>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSimpleInjector(container);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            container.Verify();
        }
    }
}
