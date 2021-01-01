using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class KanGrubu
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Kan Grubu Giriniz"))]
        [Display(Name ="Kan Grubu")]
        public string KanGrubuAd { get; set; }
    }
}
