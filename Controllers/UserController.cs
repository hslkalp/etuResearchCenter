using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;
using WebProject.Filter;
using WebProject.Models;

namespace WebProject.Controllers
{
  public class UserController : Controller
  {

    private readonly ETURContext db;

    public UserController(ETURContext context)
    {
      db = context;
    }

    private string encryptToString(string encryptString)
    {

      encryptString = createMd5.createMd5Password(encryptString);
      encryptString = createSh1.HashSh1(encryptString);
      encryptString = createMd5.createMd5Password(encryptString);
      encryptString = createSh1.HashSh1(encryptString);
      encryptString = createSh1.HashSh1(encryptString);
      encryptString = createMd5.createMd5Password(encryptString);
      encryptString = createSh1.HashSh1(encryptString);

      return encryptString;
    }

    [ServiceFilter(typeof(AdminUserSecurityAttribute))]
    [HttpGet]
    public IActionResult editProfile()
    {
      int userId = (int)HttpContext.Session.GetInt32("User_ID");
      var loginUser = db.Users.Where(User => User.UserID == userId).FirstOrDefault();
      return View(loginUser);
    }

    [ServiceFilter(typeof(AdminUserSecurityAttribute))]
    [HttpPost]
    public IActionResult editProfile(Users user)
    {
      int userId = (int)HttpContext.Session.GetInt32("User_ID");
      var foundUser = db.Users.Where(user => user.UserID == userId).FirstOrDefault();

      foundUser.Name = user.Name;
      foundUser.Surname = user.Surname;

      db.Users.Update(foundUser);
      db.SaveChanges();

      return RedirectToAction("editProfile");
    }

    [ServiceFilter(typeof(AdminUserSecurityAttribute))]
    [HttpGet]
    public IActionResult editPhoto(Users users)
    {
      int userId = (int)HttpContext.Session.GetInt32("User_ID");
      var foundUser = db.Users.Where(user => user.UserID == userId).FirstOrDefault();
      return View(foundUser);
    }

    [ServiceFilter(typeof(AdminUserSecurityAttribute))]
    [HttpPost]
    public async Task<IActionResult> editPhotoAsync(Users user, IFormFile PicturePath)
    {
      int userId = (int)HttpContext.Session.GetInt32("User_ID");
      var foundUser = db.Users.Where(user => user.UserID == userId).FirstOrDefault();
      // * resim yolu
      if (PicturePath != null)

      {
        string imageExtension = Path.GetExtension(PicturePath.FileName);

        string imageName = Guid.NewGuid() + imageExtension;

        string path = Path.Combine($"wwwroot/img/Users/{imageName}");

        using var stream = new FileStream(path, FileMode.Create);

        await PicturePath.CopyToAsync(stream);

        user.PicturePath = path;

        user.PicturePath = user.PicturePath.Substring(user.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

      }
      foundUser.PicturePath = user.PicturePath;

      db.Users.Update(foundUser);
      db.SaveChanges();

      return RedirectToAction("editPhoto");
    }

    [ServiceFilter(typeof(AdminUserSecurityAttribute))]
    [HttpGet]
    public IActionResult editAccount(Users users)
    {
      int userId = (int)HttpContext.Session.GetInt32("User_ID");
      var foundUser = db.Users.Where(user => user.UserID == userId).FirstOrDefault();

      return View(foundUser);
    }



    [ServiceFilter(typeof(AdminUserSecurityAttribute))]
    [Route("/User/editUser")]
    [HttpPost]
    public JsonResult editUser([FromBody] Users user)
    {
      try
      {
        int userId = (int)HttpContext.Session.GetInt32("User_ID");
        var foundUser = db.Users.Where(user => user.UserID == userId).FirstOrDefault();

        string Password = user.Password;
        string newPassword = user.NewPassword;
        string confirmNewPassword = user.ConfirmNewPassword;

        if (string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(newPassword) && string.IsNullOrEmpty(confirmNewPassword))
        {
          return Json(new { Result = false, Message = "Alanlar bo?? b??rakl??lamaz" });
        }
        if (string.IsNullOrEmpty(Password))
        {
          return Json(new { Result = false, Message = "Mecvut ??ifrenizi girmelisiniz!" });
        }
        if (string.IsNullOrEmpty(newPassword))
        {
          return Json(new { Result = false, Message = "Yeni ??ifrenizi girmelisiniz!" });
        }
        if (string.IsNullOrEmpty(confirmNewPassword))
        {
          return Json(new { Result = false, Message = "Yeni ??ifrenizi tekrar girmelisiniz!" });
        }
        if (encryptToString(Password) != foundUser.Password)
        {
          return Json(new { Result = false, Message = "Girmi?? oldu??unuz ??ifre mevcut ??ifreniz ile e??le??medi" });
        }
        if (newPassword != confirmNewPassword)
        {
          return Json(new { Result = false, Message = "Girmi?? oldu??unuz yeni ??ifre e??le??miyor" });
        }
        if ((newPassword == confirmNewPassword) && (foundUser.Password == encryptToString(confirmNewPassword)))
        {
          return Json(new { Result = false, Message = "Eski ??ifreniz ile yeni girmi?? oldu??unuz ??ifre ayn??" });
        }
        else
        {
          foundUser.Password = encryptToString(confirmNewPassword);

          db.Users.Update(foundUser);
          db.SaveChanges();

          return Json(new { Result = true, Message = "??ifre ba??ar??yla g??ncellendi", Url = "/User/editAccount" });
        }
      }
      catch (Exception ex)
      {
        return Json(new { Result = false, Message = ex.Message });
      }
    }
  }
}