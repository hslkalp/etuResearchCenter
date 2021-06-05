using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class IsActive
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}