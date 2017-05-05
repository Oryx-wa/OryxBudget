using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Data.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Text.Encodings.Web;
using OryxWebapi.Utilities.ErrorHandling;
using OryxWebapi.Utilities.ActionFilters;
using System.IdentityModel.Tokens.Jwt;
using OryxSecurity.Services;
using AutoMapper;
using OryxWebapi.ViewModels.Mappings;
using Data;
using OryxBudgetService;
//using Hangfire;
using System.Collections.Generic;
using IdentityServer4.AccessTokenValidation;
using System.IO;
using Hangfire;
using OryxSecurity;
using OryxMailer;

namespace OryxWebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);


            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            var policy = new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicy();

            policy.Headers.Add("*");
            policy.Methods.Add("*");
            policy.Origins.Add("*");
            policy.SupportsCredentials = true;

            services.AddCors(x => x.AddPolicy("corsGlobalPolicy", policy));
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            var MCIPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("scope", "OryxBudget")
                .Build();

           // services.AddAuthorization(options =>
          //  {
//
          //      options.AddPolicy("Administrator", policyAdmin =>
          //      {
          //          policyAdmin.RequireClaim("role", "Administrator");
          //      });
          //      options.AddPolicy("HR", policyAdmin =>
         //       {
         //           policyAdmin.RequireClaim("role", "HR");
         //       });
           //     options.AddPolicy("Employee", policyUser =>
         //       {
       //             policyUser.RequireClaim("role", "OryxBudget.user");
        //        });

        //    });

            services.AddMvcCore(config =>
            {
              //  config.Filters.Add(new AuthorizeFilter(MCIPolicy));
            })
           .AddJsonFormatters(opt =>
           {
               opt.ContractResolver = new CamelCasePropertyNamesContractResolver();
               opt.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
           });

            services.AddMvc()
                .AddJsonOptions(jsonOptions =>
                {
                    jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    //jsonOptions.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.RoundtripKind;
                });

            string conString = Configuration["Data:DefaultConnection:OryxBudgetConnectionString"];

            
            services.AddDbContext<SecurityContext>(options => options.UseSqlServer(conString, opt => opt.UseRowNumberForPaging()));
            services.AddDbContext<OryxBudgetContext>(options => options.UseSqlServer(conString, opt => opt.UseRowNumberForPaging()));

            //services.AddHangfire(x => x.UseSqlServerStorage(conString));

            Mapper.Initialize(x => x.AddProfile<MappingProfile>());

            var builder = new ContainerBuilder();


            var opt1 = new DbContextOptionsBuilder();
            opt1.UseSqlServer(conString);

            var optMail = new DefaultSenderOptions();
            optMail.SenderName = "Oryx Budget Default";
            optMail.SenderUserName = "info@oryx-wa.com";
            optMail.ServerAddress = "smtp.oryx-wa.com";
            optMail.ServerPort = 25;
            optMail.SenderPassword = "support101";
            optMail.SecureOption = MailKit.Security.SecureSocketOptions.None;
            



         


            builder.RegisterType<OryxBudgetContext>()
           .As<DbContext>()
           .WithParameter("options", opt1)
           .InstancePerLifetimeScope()
           .InstancePerBackgroundJob();


            builder.RegisterType<DbFactory>()
                .As<IDbFactory>()
                .InstancePerLifetimeScope();
                



            builder.RegisterType<HttpContextAccessor>()
                .As<IHttpContextAccessor>()
                .InstancePerDependency();

            builder.RegisterType<UserResolverService>()
                .As<IUserResolverService>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<ModuleService>();
           
            builder.RegisterModule(new BudgetDataModule())                ;
            builder.RegisterModule(new BudgetServiceModule());
            builder.RegisterModule(new OperatorServiceModule());
            builder.RegisterType<UserResolverService>();
            builder.RegisterType<ApiExceptionFilter>();
            builder.RegisterType<ValidateModelState>();





            builder.Populate(services);

            this.ApplicationContainer = builder.Build();

            GlobalConfiguration.Configuration.UseAutofacActivator(this.ApplicationContainer, false);

            return this.ApplicationContainer.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            Log.Logger = new LoggerConfiguration()
                    .WriteTo.RollingFile(pathFormat: "logs\\log-{Date}.log")
                    .CreateLogger();

            if (env.IsDevelopment())
            {
                try
                {

                    //    var dbService = this.ApplicationContainer.Resolve<WorkflowContext>();
                    //    dbService.Database.Migrate();
                }
                catch (Exception ex)
                {
                    throw ex;

                }
                loggerFactory.WithFilter(new FilterLoggerSettings
                    {
                        {"Trace",LogLevel.Trace },
                        {"Default", LogLevel.Trace},
                        {"Microsoft", LogLevel.Warning}, // very verbose
                        {"System", LogLevel.Warning}
                    })
                    .AddConsole()
                    .AddSerilog();

                app.UseDeveloperExceptionPage();
            }
            else
            {
                loggerFactory.WithFilter(new FilterLoggerSettings
                    {
                        {"Trace",LogLevel.Trace },
                        {"Default", LogLevel.Trace},
                        {"Microsoft", LogLevel.Warning}, // very verbose
                        {"System", LogLevel.Warning}
                    })
                   .AddSerilog();

                app.UseExceptionHandler(errorApp =>

                        // Application level exception handler here - this is just a place holder
                        errorApp.Run(async (context) =>
                        {
                            context.Response.StatusCode = 500;
                            context.Response.ContentType = "text/html";
                            await context.Response.WriteAsync("<html><body>\r\n");
                            await
                                context.Response.WriteAsync(
                                    "We're sorry, we encountered an un-expected issue with your application.<br>\r\n");

                            // Capture the exception
                            var error = context.Features.Get<IExceptionHandlerFeature>();
                            if (error != null)
                            {
                                // This error would not normally be exposed to the client
                                await
                                    context.Response.WriteAsync("<br>Error: " +
                                                                HtmlEncoder.Default.Encode(error.Error.Message) +
                                                                "<br>\r\n");
                            }
                            await context.Response.WriteAsync("<br><a href=\"/\">Home</a><br>\r\n");
                            await context.Response.WriteAsync("</body></html>\r\n");
                            await context.Response.WriteAsync(new string(' ', 512)); // Padding for IE
                        }));
            }

            app.UseCors("corsGlobalPolicy");


            // IdentityServerAuthenticationOptions identityServerAuthenticationOptions = new IdentityServerAuthenticationOptions();
            // identityServerAuthenticationOptions.Authority = "http://localhost:5000/";
            // identityServerAuthenticationOptions.AllowedScopes = new List<string> { "OryxBudget" };
            // identityServerAuthenticationOptions.ApiSecret = "F621F470-9731-4A25-80EF-67A6F7C5F4B8";
            // identityServerAuthenticationOptions.ApiName = "OryxBudget";
            // identityServerAuthenticationOptions.AutomaticAuthenticate = true;
            // identityServerAuthenticationOptions.SupportedTokens = SupportedTokens.Both;
            // required if you want to return a 403 and not a 401 for forbidden responses
            // identityServerAuthenticationOptions.AutomaticChallenge = true;
            // identityServerAuthenticationOptions.RequireHttpsMetadata = false;


            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //app.UseIdentityServerAuthentication(identityServerAuthenticationOptions);

          
            if (env.IsDevelopment())
            {
                try
                {
                    //var dbContext = this.ApplicationContainer.Resolve<WorkflowContext>();
                    //dbContext.Database.Migrate();

                    //var dbContext1 = this.ApplicationContainer.Resolve<OryxBudgetContext>();
                    //dbContext1.Database.Migrate();

                    //var dbContext2 = this.ApplicationContainer.Resolve<SecurityContext>();
                    //dbContext2.Database.Migrate();
                }
                catch (Exception e)
                {

                    throw e;
                }
            }
          //  app.UseHangfireDashboard();
          //  app.UseHangfireServer();

            if (!Directory.Exists("Uploads"))
            {
                Directory.CreateDirectory("Uploads");
            }

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
