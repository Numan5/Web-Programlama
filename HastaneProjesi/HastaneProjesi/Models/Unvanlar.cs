using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class Unvanlar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage =("Unvan Giriniz"))]
        [Display(Name ="Unvan Adı")]
        public string UnvanAd { get; set; }
    }
}
