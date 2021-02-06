using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICategoryService
    {
        //neyi dış dünyaya servis etmek isityorsam onları yazıyorum
        List<Category> GetAll();
        Category GetById(int Categoryid);


    }
}
