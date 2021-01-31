﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using BlogDemo.Infrastructure.Database;

namespace BlogDemo.Api
{
    /**
        create the web host
        it is a console project
        IWebHost: 
                1. configuration
                2. Kestrel server
        Program few change
            * http server
            * IIS
            * configuration information source
     */
    public class Program
    {
        /**
            IWebHostBuilder 
            build() method will return the instance of IWebHost
            Run() the function
            
         */
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var myContext = services.GetRequiredService<MyContext>();
                    MyContextSeed.SeedAsync(myContext, loggerFactory).Wait();
                }
                catch (Exception e)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(e, "Error occured seeding the Database");
                }
            }
            host.Run();
            
        }


        /**
            
         
         */
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup(typeof(StartupDevelopment).GetTypeInfo().Assembly.FullName);
    }
}
