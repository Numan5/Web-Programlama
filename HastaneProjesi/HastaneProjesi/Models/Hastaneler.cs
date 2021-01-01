using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class Hastaneler
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Hastane Adı Giriniz"))]
        [Display(Name ="Hastane Adı")]
        public string Ad { get; set; }

       
     
    }
}
