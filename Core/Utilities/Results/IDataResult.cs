using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public interface IDataResult<T>:IResult  //  T=>hangi tipi dondurecigini bana soyle
    {
        T Data { get; } //mesage ve succes dısında bir de datalarımız olacak
    }
}
