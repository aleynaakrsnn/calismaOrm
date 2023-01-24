using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calismaOrm.Models
{
    public class Urunler
    {
        public int Id { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public string Barcode { get; set; }
        public double Fiyat { get; set; }
        public int KategoriId { get; set; }

        public string Resim { get; set; }

        [ForeignKey("KategoriId")]
        public Kategori Kategori { get; set; }
    }
}
