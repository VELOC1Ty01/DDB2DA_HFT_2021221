using DDB2DA_HFT_2021221.Data;
using DDB2DA_HFT_2021221.Endpoint.Services;
using DDB2DA_HFT_2021221.Logic;
using DDB2DA_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDB2DA_HFT_2021221.Endpoint
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<F1DbContext>();

            services.AddTransient<IDriverLogic, DriverLogic>();
            services.AddTransient<IDriverRepository, DriverRepository>();

            services.AddTransient<ITeamLogic, TeamLogic>();
            services.AddTransient<ITeamRepository, TeamRepository>();

            services.AddTransient<IGrandPrixLogic, GrandPrixLogic>();
            services.AddTransient<IGrandPrixRepository, GrandPrixRepository>();

            services.AddTransient<IQueryLogic, QueryLogic>();

           
            services.AddControllers();

            services.AddSignalR();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDB2DA_HFT_2021221.Endpoint", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDB2DA_HFT_2021221.Endpoint v1"));
            }
            
            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseCors(x => x
                 .AllowCredentials()
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .WithOrigins("http://localhost:25895"));

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
