using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class HastaSikayeti
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Hasta Şikayeti Giriniz"))]
        [DisplayName("Hasta Şikayeti")]
        public string HastaSikayet { get; set; }

        public int? HastaKabulId { get; set; }
        public HastaKabul HastaKabul { get; set; }
    }
}
