using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Labs
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddUserID { get; set; }
        public DateTime AdditionDate { get; set; }
        public string Language { get; set; }
        public int SubstructureID { get; set; }
        public string PicturePath { get; set; }
    }
}