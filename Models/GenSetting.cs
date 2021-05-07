using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class GenSetting
    {
        [Key]
        public int Id { get; set; }
        public int EkleyenKisiID { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public string SiteAdi { get; set; }
        public string MetaAuthor { get; set; }
        public string MetaKeyWords { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePlus { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Youtube { get; set; }
        public string MetaDescription { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string WebAdres { get; set; }
        public int DuzenleyenKisiID { get; set; }
        public DateTime DuzenlenmeTarihi { get; set; }
        public string KisaTarihce { get; set; }
        public string Adres { get; set; }
        public string language { get; set; }
    }
}