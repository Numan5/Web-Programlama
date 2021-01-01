using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class Ilaclar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Fiyat Giriniz"))]
        public int? Fiyat { get; set; }
        [Required(ErrorMessage = ("Adet Giriniz"))]
        [Display(Name ="Kaç Adet")]
        public int? Adet { get; set; }
        public int? ReceteId { get; set; }
        public Recete Recete { get; set; }
    }

}
