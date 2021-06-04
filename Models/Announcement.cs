using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AddUserID { get; set; }
        public DateTime AdditionDate { get; set; }
        public string Language { get; set; }
        public string PicturePath { get; set; }
        public string ShortText { get; set; }

    }
}