using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class UstMenu
    {
        [Key]
        public int Id { get; set; }

        public Nullable<int> ParentId { get; set; }

        public string Adi { get; set; }

        public string Link { get; set; }

        public Nullable<int> Sira { get; set; }

        public bool AktifMi { get; set; }
        public string Language { get; set; }
        public bool YeniSayfadaAc { get; set; }
    }
}