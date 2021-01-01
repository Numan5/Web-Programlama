using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class Doktorlar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Adı Giriniz"))]
        public string Ad { get; set; }

        [Required(ErrorMessage = ("Soyadı Giriniz"))]
        public string Soyad { get; set; }
        [Required(ErrorMessage = ("Doğum Yerini Giriniz"))]
        public string DogumYeri { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }
        public int? UnvanlarId { get; set; }
        public int? PoliniklikId { get; set; }
        public Unvanlar Unvanlar { get; set; }
        public Poliniklik Poliniklik { get; set; }
    }
}
