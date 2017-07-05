using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BudgetReport.Services;
using Microsoft.EntityFrameworkCore;
using BudgetReport.Filters;
using Newtonsoft.Json.Serialization;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace BudgetReport
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            services.AddMvcCore(config =>
            {
                config.Filters.Add(typeof(CustomExceptionFilter));
            })
                 .AddAuthorization()
                 .AddJsonFormatters(opt =>
                 {
                     opt.ContractResolver = new CamelCasePropertyNamesContractResolver();
                     opt.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                 });

            var builder = new ContainerBuilder();


            var optRep = new CrystalOptions();
            optRep.DatabaseName = Configuration["CrystalReport:DatabaseName"];
            optRep.ServerName = Configuration["CrystalReport:ServerName"];
            optRep.UserId = Configuration["CrystalReport:UserId"];
            optRep.Password = Configuration["CrystalReport:Password"];
            optRep.payslipRpt = Configuration["CrystalReport:payslipRpt"];
            optRep.reportsFolder = Configuration["CrystalReport:reportsFolder"];

            builder.RegisterType<ReportService>()
                .WithParameter("crystalOptions", optRep)
                .InstancePerLifetimeScope();

            builder.Populate(services);

            this.ApplicationContainer = builder.Build();
            //GlobalConfiguration.Configuration.UseAutofacActivator(this.ApplicationContainer, false);
            return this.ApplicationContainer.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
           

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseMvc(config =>
            {
                config.MapRoute(
                  name: "Default",
                  template: "{controller}/{action}/{id?}"
                  );


            });
        }
    }
}
