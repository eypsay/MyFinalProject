using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  
    public class ErrorDataResult<T> : DataResult<T> //burada amacımız islem souncunda defalut olarak false vermek icin
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)//data olarak sen defaultunu kullan
        {

        }
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
