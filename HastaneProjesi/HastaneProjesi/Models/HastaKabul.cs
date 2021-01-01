using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class HastaKabul
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Geliş Tarihi")]
        public DateTime GelisTarihi { get; set; }
        public int? HastalarId { get; set; }
        public int? DoktorlarId { get; set; }

        public Hastalar Hastalar { get; set; }
        public Doktorlar Doktorlar { get; set; }
    }
}
