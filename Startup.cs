using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using LiquidApi.Context;
using LiquidApi.Repositories;
using LiquidApi.Factories;
using LiquidApi.Services;

namespace LiquidApi
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
            services.AddControllers();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerFactory, CustomerFactory>();
            services.AddTransient<ICustomerService, CustomerService>();

            services.AddDbContext<LiquidApiContext>(opt => opt.UseInMemoryDatabase("LiquidDb", null));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using var serviceScope = app.ApplicationServices.CreateScope();
            LiquidApiContext context = serviceScope.ServiceProvider.GetService<LiquidApiContext>();
            DataSeed.AddSeedData(context);
        }
    }
}
