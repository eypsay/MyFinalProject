using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint
    //class: refeans tip olabilir
    //IEntity: IEntity olabilir veya IEntity implemente eden ir nesne olablir
    //new(): new lenebilir olmalı

   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        // bu expressionları, linq sorgularını yazabilmemizi saglaaycak
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //bunun yerine GetAll ve Get için expression yazdik
        //List<T> GetAllCategory(int categoryID);

    }
}
