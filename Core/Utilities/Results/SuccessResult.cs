using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
  public  class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)//bu base Result classını kasdediyor
        {

        }
        //mesaj vermek istenmiyorumsam
        public SuccessResult():base(true)//burada true default vermiş olduk
        {

        }
    }
}
