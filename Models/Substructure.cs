using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class Substructure
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int AddUserID { get; set; }
        [ForeignKey("AddUserID")]
        public Users Users { get; set; }
        public DateTime AdditionDate { get; set; }
        public string Language { get; set; }
        public string PicturePath { get; set; }
    }
}