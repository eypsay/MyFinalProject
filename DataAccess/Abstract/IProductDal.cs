using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    //product tablosuna iat interface
    public interface IProductDal:IEntityRepository<Product>
    {
      //Buraya product a öozel işlemeri yazacağız. prduct detail gibi 

    }
}
