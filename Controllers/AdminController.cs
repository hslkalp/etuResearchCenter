using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebProject.Data;
using WebProject.Filter;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly ETURContext db;

        public AdminController(ETURContext context)
        {
            db = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        // [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        [Route("/Admin/loginQuery")]
        public JsonResult LoginQuery([FromBody] Users data)
        {
            try
            {
                string Email = data.Email;
                string Password = data.Password;

                if (string.IsNullOrEmpty(Password) && string.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı ve Şifrenizi Girmediniz!" });
                }
                else if (string.IsNullOrEmpty(Email))
                {
                    return Json(new { Result = false, Message = "Kullanıcı Adınızı giremediniz" });
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    return Json(new { Result = false, Message = "Şifrenizi Girmediniz" });
                }
                else
                {
                    var user = db.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password && x.Role == 1);

                    if (user == null) return Json(new { Result = false, Message = "Kullanıcı Adı veya Parola hatalı" });

                    HttpContext.Session.SetInt32("User_ID", user.Id);
                    HttpContext.Session.SetString("Name", user.Name);
                    HttpContext.Session.SetString("Surname", user.Surname);
                    HttpContext.Session.SetString("PicturePath", user.PicturePath);
                    HttpContext.Session.SetInt32("Role", user.Role);
                    HttpContext.Session.SetInt32("UserRole", user.Role);
                    HttpContext.Session.SetInt32("AdminRole", user.Role);

                    return Json(new { Result = true, Message = "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz..", Url = "/Admin/Home" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });

            }
        }


        public IActionResult logOut()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}