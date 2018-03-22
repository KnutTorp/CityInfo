using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter())); // support for xml response
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
