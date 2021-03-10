using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Security.Encryption;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Core.Extentions;
using Core.DependencyResolvers;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Autofac,Ninject,CastleWindsor,SturcterMap,LightInject,DryInject-->IoC Container
            //biz AOP yapcagýz -> bir metonun onunde, sonunda veya hata alabilceði  calýsan kod parcacýklarýdýr
            services.AddControllers();
            //asagidaki kodlarý biz modlu yazdýgýmýz icin kapattýk bunun yerine program.cs
            //singleton eger icerisinde data tutmuyorsa kullanýlýr
            //services.AddSingleton<IProductService, ProductManager>();//arkaplaönd bir refrans olsutur, bizim yerimize new liyor
            //services.AddSingleton<IProductDal, EfProductDal>();


            //services.AddSingleton<HttpContextAccessor,IHttpContextAccessor>();//bunun yerine asaigdak, addddependency kýsmýný yazdýk

            services.AddCors();//frontend farklý porttan get yapmak icin ekeldik
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };                     
                });
            //ServiceTool.Create(services);
            services.AddDependencyResolvers(new ICoreModule[] {
                new CoreModule() 
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder=>builder.WithOrigins("http://localhost:4200").AllowAnyHeader());//frontend farklý porttan get yapmak icin ekeldik
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
