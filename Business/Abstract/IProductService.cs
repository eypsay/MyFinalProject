using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {

        //bunn yerine alttaki kodla değişirdik 
        //List<Product> GetAll();//bunn yerşne alataki kodla değişirdik
        // List<Product> GetAllByCategoryId(int id);
        // List<Product> GetByUnitPrice(decimal min,decimal max);
        // List<ProductDetailDto> GetProductDetails();
        //void  Add(Product product) ;
        // Product GetById(int productId);

        IDataResult<List<Product>> GetAll();//burada hem bir liste hemde dataları koyan bir yapı
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult< List<ProductDetailDto>> GetProductDetails();     
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);
    }
}
