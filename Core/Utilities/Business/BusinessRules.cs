using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public class BusinessRules
    {
        //bana iş kurallarını gönder
        public static IResult Run(params IResult[] logics)//isteiğm kadar IResult verebilirim params kulandığı için
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)//parametre ile gönderilen iş kurallarından başarısz olanları iş kurallarına bildiriyoruz yani kuralın kendisini döndüroyruz
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
