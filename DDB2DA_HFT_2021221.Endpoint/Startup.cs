using DDB2DA_HFT_2021221.Data;
using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Endpoint
{
    public class Startup
    {
         public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<F1DbContext, F1DbContext>();

            services.AddSingleton<IDriverLogic, DriverLogic>();
            services.AddSingleton<IDriverRepository, DriverRepository>();

            services.AddSingleton<ITeamLogic, TeamLogic>();
            services.AddSingleton<ITeamRepository, TeamRepository>();

            services.AddSingleton<IGrandPrixLogic, GrandPrixLogic>();
            services.AddSingleton<IGrandPrixRepository, GrandPrixRepository>();

            services.AddSingleton<IQueryLogic, QueryLogic>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else 
                app.UseExceptionHandler("/Error");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
