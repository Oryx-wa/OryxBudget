using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OryxBudgetWeb.Data;
using OryxBudgetWeb.Models;
using OryxBudgetWeb.Services;

using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace OryxBudgetWeb
{
    public class Startup
    {
        public IContainer ApplicationContainer { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see https://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            

            //services.AddTransient <IOpe, OperatorRepository>();

            services.AddIdentityServer()
                     .AddTemporarySigningCredential()
                     .AddInMemoryIdentityResources(Config.GetIdentityResources())
                     .AddInMemoryApiResources(Config.GetApiResources())
                     .AddInMemoryClients(Config.GetClients())
                     .AddAspNetIdentity<ApplicationUser>()
                     .AddProfileService<AspIdProfileService>();

            
            var opOptions = new OpOptions();
            opOptions.IdPath = Configuration["IdPath"];
            opOptions.ApiPath =  Configuration["ApiPath"];


            var builder = new ContainerBuilder();

            builder.RegisterType<OperatorsClient>()
                .WithParameter("opOptions", opOptions)
                 .InstancePerLifetimeScope();
               


            builder.Populate(services);

            this.ApplicationContainer = builder.Build();
            return this.ApplicationContainer.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile(Configuration.GetSection("Logging"));



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.Use(async (context, next) =>
            //{
            //  await next();

            //        // If there's no available file and the request doesn't contain an extension, we're probably trying to access a page.
            //        // Rewrite request to use app root
            //        if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api"))
            //  {
            //    context.Request.Path = "/index.html";
            //    context.Response.StatusCode = 200; // Make sure we update the status code, otherwise it returns 404
            //          await next();
            //  }
            //});

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseIdentityServer();

            // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
                  {
                      routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                  });
        }
    }
}
