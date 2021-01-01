using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneProjesi.Models
{
    public class Hastalar
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = ("Ad Giriniz"))]
        public string Ad { get; set; }
        [Required(ErrorMessage = ("Soyad  Giriniz"))]
        public string Soyad { get; set; }

        
        [DataType(DataType.Date)]
        public DateTime DogumTarihi { get; set; }
        [Display(Name ="Medeni Hali")]
        public MedeniHali MedeniHali { get; set; }
        [Required(ErrorMessage = ("Doğum Yerini Giriniz"))]
        [Display(Name = "Doğum Yeri")]
        public string DogumYeri { get; set; }
        public string Meslek { get; set; }
        public int? KanGrubuId { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public KanGrubu KanGrubu { get; set; }
    }
}
