using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //ProductManager productManager = new ProductManager(new InMemoryProductDal());

            //foreach (var product in productManager.GetAll())
            //{
            //    Console.WriteLine(product.ProductName);
            //}


            /////ENTITY FRAMEWORK
             ProductTest();
            //IoC conteiner ile yapınca new Efca... kısmını kaldıracazı
           // CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));

            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("-------CATEGORY ID-------------");
            foreach (var product in productManager.GetAllByCategoryId(2).Data)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("-------UNITPROCE MIN-MAX-------------");
            foreach (var product in productManager.GetByUnitPrice(50, 100).Data)
            {
                Console.WriteLine("Name: {0} -- Price: {1}", product.ProductName, product.UnitPrice);
            }
            Console.WriteLine("-------PRODUCT NAME => CATEGORY NAME-------------");

            //Assagıdaki gibi degistirdik
            //foreach (var product in productManager.GetProductDetails ())
            //{
            //    Console.WriteLine(product.ProductName+" ----> "+product.CategoryName);
            //}

            var result = productManager.GetProductDetails();
            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine((product.ProductName+" / "+product.CategoryName));
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
