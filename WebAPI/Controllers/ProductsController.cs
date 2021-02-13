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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            //Swagger
            //IProductService productService = new ProductManager(new EfProductDal());
            //var result = productService.GetAll();
            //return result.Data;////Dependency Chain oldugundan asagıdaki kodla degisitirdik

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            //return result.Data;
            return BadRequest(result);

        }
        [HttpGet("getbyid")]//isim verdik sadece
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {

            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
