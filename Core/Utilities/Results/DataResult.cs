using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>//sen bir Resultsın
    {
        public DataResult(T data,bool success,string message):base(success,message)//base gelen message ve successi ver
        {
            Data = data;
        }
        public DataResult(T data, bool success):base(success)//base success i ver
        {
            Data = data;
        }
        public T Data { get; }
    }
}
