using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class GenSetting
    {
        [Key]
        public int Id { get; set; }
        public int AddUserID { get; set; }
        public DateTime AdditionDate { get; set; }
        public string WebsiteName { get; set; }
        public string MetaAuthor { get; set; }
        public string MetaKeyWords { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string GooglePlus { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Youtube { get; set; }
        public string MetaDescription { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string WebAddress { get; set; }
        public int OrganizerID { get; set; }
        public DateTime IssueDate { get; set; }
        public string ShortHistory { get; set; }
        public string Address { get; set; }
        public string language { get; set; }
    }
}