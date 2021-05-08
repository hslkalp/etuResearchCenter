using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public int AddUserID { get; set; }
        public DateTime AdditionDate { get; set; }
        public string Language { get; set; }
        public string SubTitle { get; set; }
        public Nullable<int> Queue { get; set; }
        public bool IsActive { get; set; }
        public string Link { get; set; }
    }
}