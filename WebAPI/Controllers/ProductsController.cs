using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //bir katman diger katmanın somutuna ulasamassanız yani new lememeliyiz
        //Loose coupled - gevsek baglılık

        //IoC Container ---Inersion of Controller -- degisimin controlu
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {

            ////Dependency Chain oldugundan asagıdaki kodla degisitirdik
            //IProductService productService = new ProductManager(new EfProductDal());
            //var result = productService.GetAll();
            //return result.Data;

            var result = _productService.GetAll();
            return result.Data;



        }
    }
}
