using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        
        // get methodu read-only dir fakat sadece constructerde değer ataması yapıalbilir
        //set olarakd a yazabilirdik fakat yazlımcı bask verlede set etmesin diye bu yapıyı kurduk
        //cosntructuer base olarak çalışması örneği =>this(success)
        public Result(bool success, string message):this(success)// this demek classın kendisi demektir ayrıca tek parametreli construda çalıştır demek
        {
            Message = message;
           // Success = success; bu işi alttaki consturtera verdik
        }


        public Result(bool success)
        {
            
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
