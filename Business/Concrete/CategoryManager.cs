using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        //burası veri erişimine aglı bunu miniöize etmek için bağımlıgımı constructur injection
        // ile yapıyorum
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }





        //Is kodlarını buraya yazacagım
        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();


        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryID == categoryId);
        }
    }
}
