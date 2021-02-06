using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //veritabainndan geliyormus gibi simule ettik
            _products = new List<Product>() { 
            new Product {ProductId=1, CategoryID=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product {ProductId=2, CategoryID=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product {ProductId=3, CategoryID=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product {ProductId=4, CategoryID=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product {ProductId=5, CategoryID=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }

        public void Add(Product product)
        {
            //throw new NotImplementedException();
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            /*//LINQ olamdan yaparsak
            Product productToDelete =null;            
            foreach (var p in _products)
            {
               if(product .ProductId== p.ProductId)
                {
                    productToDelete = p;
                } 
            }
            ////////*/

            /////LINQ ile yazarsam. SingleOrDefault tek tek dolasarak elaman bulmak 
            ///Lampda p=>
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);


            _products.Remove(productToDelete);

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            //throw new NotImplementedException();
            return _products ;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllCategory(int categoryID)
        {
            // throw new NotImplementedException();
            return _products.Where(p => p.CategoryID == categoryID).ToList();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //throw new NotImplementedException();
            //gonderdigim urun ID'sine sahip olan listedeki urunu bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
