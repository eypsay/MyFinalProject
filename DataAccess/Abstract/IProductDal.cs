using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    //product tablosuna iat interface
    public interface IProductDal
    {
        List<Product> GetAll();

        void Add(Product product );
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllCategory(int categoryID);

    }
}
