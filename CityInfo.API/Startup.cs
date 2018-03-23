using CityInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.API
{
    public class Startup
    {
        //public static IConfigurationRoot Configuration;
        public static IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {

            // in .net core v1 this is how to do it. this is automatic in v2
            //var configBuilder = new ConfigurationBuilder()
            //    .SetBasePath(env.ContentRootPath)
            //    .AddJsonFile("appSettings.json", optional:false, reloadOnChange:true)
            //    .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            //Configuration = configBuilder.Build();
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter())); // support for xml response- can set contenttype application/xml on the request
                                                                                                             //.AddJsonOptions(o =>
                                                                                                             //{
                                                                                                             // For changeing from camelcase to property names as is. Capital first letter

            //    if (o.SerializerSettings.ContractResolver != null)
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
            //        // The default naming strategy is camelcasing properties in respons. // id, citiName
            //        // When we don't use a nameing strategy the response will contain properties with the property names //Id, CityName
            //        // Exosting consumers might expect this.
            //        castedResolver.NamingStrategy = null;
            //    }

            //    //// This is what Resharper wants to turn it into
            //    //switch (o.SerializerSettings.ContractResolver)
            //    //{
            //    //    case null:
            //    //        return;
            //    //    case DefaultContractResolver castedResolver:
            //    //        castedResolver.NamingStrategy = null;
            //    //        break;
            //    //}

            //});

#if DEBUG
            services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();
            app.UseMvc();

            //app.Run((context) =>
            //{
            //    throw new Exception("Example exception");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
