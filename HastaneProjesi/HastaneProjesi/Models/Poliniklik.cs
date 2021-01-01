using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class Poliniklik
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Polinik Adı Giriniz"))]
        [Display(Name ="Polinik Adı")]
        public string PolinikAd { get; set; }

   
        public int? HastanelerId { get; set; }
        [ForeignKey("HastanelerId")]
        public Hastaneler Hastaneler { get; set; }
    }
}
