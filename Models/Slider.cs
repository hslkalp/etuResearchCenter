using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Resim { get; set; }
        public string Aciklama { get; set; }
        public int EkleyenKisiID { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public string Language { get; set; }
        public string AltBaslik { get; set; }
        public Nullable<int> Sira { get; set; }
        public bool AktifMi { get; set; }
        public string Link { get; set; }
    }
}