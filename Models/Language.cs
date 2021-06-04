using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}