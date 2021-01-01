using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class Tahliller
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Tahlil Adı Giriniz"))]
        public string TahlilAd { get; set; }
        [Required(ErrorMessage = ("Tahlil Sonucu Griniz"))]
        public string TahlilSonucu { get; set; }

        public int? HastaGecmisiId { get; set; }
        [ForeignKey("HastaGecmisiId")]
        public HastaGecmisi hastaGecmisi { get; set; }
    }
}
