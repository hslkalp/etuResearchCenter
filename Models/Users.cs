using System;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
  public class Users
  {
    [Key]
    public int UserID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Institution { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PicturePath { get; set; }
    public DateTime AdditionDate { get; set; }
    public int Role { get; set; }
  }
}