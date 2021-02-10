using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message)//bu base Result classını kasdediyor
        {

        }
        //mesaj vermek istenmiyorumsam
        public ErrorResult() : base(false)//burada true default vermiş olduk
        {

        }
    }
}
