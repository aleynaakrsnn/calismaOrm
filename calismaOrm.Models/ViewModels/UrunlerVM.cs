using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;




namespace calismaOrm.Models.ViewModels
{
    public class UrunlerVM
    {
        public Urunler Urunler { get; set; }
        public IEnumerable<SelectListItem> KategoriList { get; set; }





        //Not : eger selectlistitem hata verirse ana sunum katmanda model klasörünü silip silmedine dikkat et ltfen,birde models klasörü içindeki errorviewmodel yazan classı model katmanına tasımayı unutma 
    }
}
