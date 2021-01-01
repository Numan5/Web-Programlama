using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class HastaGecmisi
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = ("Geçirdiği Hastalığı Boş Bırakmayın"))]
        [Display(Name = "Geçirdiği Hastalıklar")]
        public string GecirdigiHastaliklar { get; set; }
        [Required(ErrorMessage = ("Geçirdiği Ameliyatı Boş Bırakmayınız"))]
        public string GecirdigiAmeliyatlar { get; set; }

        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }
        public int? HastaSikayetiId { get; set; }
        [ForeignKey("HastaSikayetiId")]
        public HastaSikayeti HastaSikayeti { get; set; }

    }
}
