using BlogDemo.core.Interfaces;
using BlogDemo.Infrastructure.Database;
using BlogDemo.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
    public class StartupDevelopment
    {
        /*
            service registration
         */

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlite("Data Source=BlogDemo.db");
            });
            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 5001;
            });



            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            
        }


        /*
            config middleware pipline, can use the service registed in the ConfigureServices function
         */
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
