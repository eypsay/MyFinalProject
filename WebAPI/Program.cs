using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //*bizim yazdýgýmýz configurasyon
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())  //.NET'e senin IOC yapýný kullanma, benim yapýmý kullanservis saglayýcý fabrikasý olarak kullan 
                .ConfigureContainer<ContainerBuilder>( builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());//business katmadýndaki bizim yazdgýmýz module
                })

            //*
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
