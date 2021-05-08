using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class TopMenu
    {
        [Key]
        public int Id { get; set; }

        public Nullable<int> ParentId { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public Nullable<int> Queue { get; set; }

        public bool IsActive { get; set; }
        public string Language { get; set; }
        public bool TargetBlank { get; set; }
    }
}