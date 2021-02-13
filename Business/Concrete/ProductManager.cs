using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //bussines kodlar: Urunu eklemden önce kısıtlar buraya yazılır
            if (product.ProductName.Length < 2)
            {
                //stringleri ayrı ayrı yazmak magic string denir
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        //public List<Product> GetAll()
        //{
        //    //Is Kodlari
        //    // throw new NotImplementedException();

        //    //HATALI!!!=> InMemoryProdcutDal inMemoryProductDal =new InmemoryProductDal();

        //    //yetkisi var mi?
        //    return _productDal.GetAll();
        //}

        //public List<Product> GetAllByCategoryId(int id)
        //{
        //    return _productDal.GetAll(p => p.CategoryID == id);
        //}

        //public Product GetById(int productId)
        //{
        //    return _productDal.Get(p => p.ProductId == productId);
        //}

        //public List<Product> GetByUnitPrice(decimal min, decimal max)
        //{
        //    return _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max);
        //}

        //public List<ProductDetailDto> GetProductDetails()
        //{
        //    return _productDal.GetProductDetails();
        //}

        //////////////////////////////////////////////
        ///

        public IDataResult< List<Product>> GetAll()
        {
            //Is Kodlari
            // throw new NotImplementedException();

            //HATALI!!!=> InMemoryProdcutDal inMemoryProductDal =new InmemoryProductDal();

            //yetkisi var mi?
            // return _productDal.GetAll();
            if (DateTime.Now.Hour == 12)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);//sistemi bu saaate kapamak istiyorum
            }

            //return new DataResult<List<Product>>(_productDal.GetAll(),true,"ürünler listelendi");
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryID == id));
        }

        public IDataResult<Product >GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult < List < Product >> (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto> >GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);//sistemi bu saaate kapamak istiyorum
            }

            return new SuccessDataResult< List < ProductDetailDto >> (_productDal.GetProductDetails());
        }
    }
}
