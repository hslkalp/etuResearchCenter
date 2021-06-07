using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class Management
    {
        [Key]

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }
        public int Queue { get; set; }

        public DateTime AdditionDate { get; set; }
        public int OrganizerID { get; set; }
        public DateTime IssueDate { get; set; }
        public bool IsStaff { get; set; }
        public string StaffStatus { get; set; }
        public int AddUserID { get; set; }
        [ForeignKey("AddUserID")]
        public Users Users { get; set; }

    }
}