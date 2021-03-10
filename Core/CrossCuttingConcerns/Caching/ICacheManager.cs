using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
   public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);// generic olmayan

        void Add(string key, object value,int duration);
        bool IsAdd(string key);//chace den mi yok db den mi
        void Remove(string key);//cahce den ucrma
        void RemovePattern(string pattern);//icindekine göre chaceden ucurma

    }
}
