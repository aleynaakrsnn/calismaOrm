﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calismaOrm.Models
{
    public class Kategori
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string KategoriAdi { get; set; }
    }
}
