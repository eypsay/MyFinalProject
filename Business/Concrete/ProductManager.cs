using Business.Abstract;
using Business.BussinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    //bir entity manager kendisinden hariç başka bir DALı enjekte edemez!!!!!Fakt servisi enjecte ederiz
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        //ILogger _logger;
        //public ProductManager(IProductDal productDal,ILogger logger)
        //{
        //    _productDal = productDal;
        //    _logger = logger;
        //}

        ///ORJİNALİ
        //public ProductManager(IProductDal productDal)
        //{
        //    _productDal = productDal;
        //}

        //yeni kural için yaptık bu kısmı
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }


        //Claim bunların admin veya product.add yetksinde olasmı gerekiyor
       [SecuredOperation( "product.add,admin")]//prodcut.ad yetkisine sahip olaması gerekiyor

        [ValidationAspect(typeof(ProductValidator))]//add methodumuzda validation yok çünkü aspect ekledik


        public IResult Add(Product product)
        {
            //bussines kodlar: Urunu eklemden önce kısıtlar buraya yazılır
            //busines codu ayrı validation kodu ayrı yazılır
            //dogrulama(validation), nesnenin iş kurallarına yapısal oalrak uyup uymadığını kontrol edilmesidir.
            //is kuralı, iş ihtiyaçlarımıza uygunluktur. ör kişinin krediye uygun olup oladığı bir iş kodudur.
            //asagidaki kodlardan fluent validation ile kurtulacagiz bular artık fluentValidaiton'ın altında
            //if (product.UnitPrice <= 0)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            //if (product.ProductName.Length < 2)
            //{
            //    //stringleri ayrı ayrı yazmak magic string denir
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}


            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if(!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}

            // ValidationTool.Validate(new ProductValidator(), product);    [validaonaspect]'İ yazdığımız için comment ettik


            //////////////////////////////25022021 kodları aşagıdakiler
            //_logger.Log();//burayı methodun basında, try iiinde vey methodun sonunda kullanailiriz
            //try
            //{
            //    _productDal.Add(product);
            //    return new SuccessResult(Messages.ProductAdded);
            //}
            //catch (Exception exception)
            //{

            //    _logger.Log();
            //}
            //return new ErrorResult();

            //iş kuralı yazdığım için onun içine aldım
            //_productDal.Add(product);
            //return new SuccessResult(Messages.ProductAdded);


            //iş kuralları yöneticler tarafında belirlenir ornegin categorymizde en fazla 10 ürün olmalıdır gib
            //validation: girilen urun biligisinin bizim yapımıza uygn olup olamdığı

            ///*** bir categoride 10 ürün olacak 
            ///bu bir iş kuralı parçasıdır bundan dolayı kodda ayrı bir method ve private olarqak yazılması gerekir
            //var result = _productDal.GetAll(p => p.CategoryID == product.CategoryID).Count;
            //if(result>=10)
            //{
            //    return new ErrorResult(Messages.ProductCountOfCategoryError);
            //
            ////* 2.kural: aynı isimde ürün eklenemez
            ///


            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryID).Success)
            //{
            //    if (CheckIfProductNameExists(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);
            //        return new SuccessResult(Messages.ProductAdded);
            //    }

            //}
            //return new ErrorResult();
            //yukardakinin yerine aşağıdaki kodları ekledik

            // biz bir iş motoru yazsak çünkü iş kurallarımız hep IRuselt. Yani bne göndereiym benim yerime bu iş kurallarını çalıştırsın

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryID), CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

            ///yeni kural: eğer mevcut categori sayıs 15i geçtiyse sisteme yeni ürün eklenemez
            ///


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

    public IDataResult<List<Product>> GetAll()
    {
        //Is Kodlari
        // throw new NotImplementedException();

        //HATALI!!!=> InMemoryProdcutDal inMemoryProductDal =new InmemoryProductDal();

        //yetkisi var mi?
        // return _productDal.GetAll();
        if (DateTime.Now.Hour == 8)
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

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
        if (DateTime.Now.Hour == 1)
        {
            return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);//sistemi bu saaate kapamak istiyorum
        }

        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    [ValidationAspect(typeof(ProductValidator))]
    public IResult Update(Product product)
    {
        ///*** bir categoride 10 ürün olacak 
        var result = _productDal.GetAll(p => p.CategoryID == product.CategoryID).Count;
        if (result >= 10)
        {
            return new ErrorResult(Messages.ProductCountOfCategoryError);
        }


        _productDal.Update(product);
        return new SuccessResult(Messages.ProductUpdated);
    }

    //İş kuralı parcacığı olduğu için privatedir
    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
            
        var result = _productDal.GetAll(p => p.CategoryID == categoryId).Count; //=> select count(*) from products where categoryId=1
            if (result >= 10)
        {
            return new ErrorResult(Messages.ProductCountOfCategoryError);


        }
        return new SuccessResult();

    }

        private IResult CheckIfProductNameExists(string productName)
        {

            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //=> select productName from products where productName=productName -> any var mı yok mu yani booleaa dodnutur 
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);


            }
            return new SuccessResult();

        }

        //kategori servisini kullanan bir ürünün onu nasıl ele aldığı ile alakalı
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
