using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class Recete
    {   [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("İlaç Adını Giriniz"))]
        [Display(Name ="İlac Adı")]
        public string IlacAd { get; set; }
       
        public int? TahlillerId { get; set; }
        public Tahliller Tahliller { get; set; }
    }
}
