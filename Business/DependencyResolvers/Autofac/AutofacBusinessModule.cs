﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
  public  class AutofacBusinessModule:Module
    {
        //webapinin start ındaki IOC container yapısnı biz burda yapuyoruz
        protected override void Load(ContainerBuilder builder)
        {
            //base.Load(builder);
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();   //bu singleton karsılık gelir yani IProductService isteyene ProductManger ver
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();   //bu singleton karsılık gelir yani ICategoryService isteyene ProductManger ver
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            //  builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance();//ASPECT anlasıksın diye ekledik ve kaldırdık
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();



          // builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
