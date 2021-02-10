using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    //static newlenmez boylece tek bir instanceta tutlur.Instance oluşturmaya gerek olamayan yapıdır
  public static  class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Gecersiz";
        public static string MaintenanceTime = "Bakım Zamanı";
        public static string ProductListed = "Urunler Listelendi";
    }
}
