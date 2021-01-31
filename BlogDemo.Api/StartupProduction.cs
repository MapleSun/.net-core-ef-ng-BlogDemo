using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDemo.Api
{
    /**
        StartUp: custom behavior, change fruquently
            * build, service, function registration
            * middleware pipeline, MVC
     */
    public class StartupProduction
    {
        /*
            service registration
         */

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
            });
        }


        /*
            config middleware pipline, can use the service registed in the ConfigureServices function
         */
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            
            app.UseMvc();
            app.UseHttpsRedirection();
        }
    }
}
