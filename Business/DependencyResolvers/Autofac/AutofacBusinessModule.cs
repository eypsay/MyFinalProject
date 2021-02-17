using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
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
        }
    }
}
