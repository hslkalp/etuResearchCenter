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
    [HttpPost]
    public IActionResult editAccount(Users users, string new_password, string confirm_new_password)
    {
      int userId = (int)HttpContext.Session.GetInt32("User_ID");
      var foundUser = db.Users.Where(user => user.UserID == userId).FirstOrDefault();

      try
      {
        if ((foundUser.Password == encryptToString(users.Password)) && (new_password == confirm_new_password))
        {
          foundUser.Password = encryptToString(confirm_new_password);

          db.Users.Update(foundUser);
          db.SaveChanges();

          System.Console.WriteLine("şifre başarıyla güncellendi");

        }
        else
        {
          System.Console.WriteLine("eski şifre yanlış veya şifreler uyuşmuyor");
        }
      }
      catch (Exception ex)
      {
        System.Console.WriteLine(ex);
      }

      return RedirectToAction("editAccount");
    }

  }
}