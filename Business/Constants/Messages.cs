﻿using System;
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
        public static string ProductCountOfCategoryError="Categorideki Ürün Limitini Aştınız";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string ProductNameAlreadyExists="Aynı İsimde Ürün Var";
        public static string CategoryLimitExceded="Kategori Limiti Aşıldı";
    }
}
