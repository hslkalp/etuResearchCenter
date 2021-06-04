using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //[ServiceFilter(typeof(AdminUserSecurityAttribute))]
        public IActionResult Home()
        {
            // * inner join ile giriş yapan kullanıcın bilgileri diğer tablo ile birleştirildi
            var userId = HttpContext.Session.GetInt32("User_ID");
            var query = from users in db.Users
                        join roles in db.Role on users.Role equals roles.Id
                        where users.UserID == userId
                        select new LoggedUser
                        {
                            user = users,
                            role = roles
                        };
            var viewModel = new ViewUsers { loggedUsers = query.ToList() };
            return View(viewModel);
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

                    var user = db.Users.FirstOrDefault(x => x.Email == Email && x.Password == Password);


                    if (user == null) return Json(new { Result = false, Message = "Kullanıcı Adı veya Parola hatalı" });

                    HttpContext.Session.SetInt32("User_ID", user.UserID);
                    HttpContext.Session.SetString("Name", user.Name);
                    HttpContext.Session.SetString("Surname", user.Surname);
                    HttpContext.Session.SetString("PicturePath", user.PicturePath);
                    HttpContext.Session.SetInt32("Role", user.Role);
                    HttpContext.Session.SetInt32("UserRole", user.Role);
                    HttpContext.Session.SetInt32("AdminRole", user.Role);
                    HttpContext.Session.SetString("Institution", user.Institution);
                    // HttpContext.Session.SetString("Email", user.Email); ?

                    return Json(new { Result = true, Message = "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz..", Url = "/Admin/Home" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });

            }
        }

        [HttpPost]
        public IActionResult logOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        //[ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * Duyurular
        public IActionResult Announcements()
        {
            ViewData["Title"] = "Duyurular";
            var announcement = db.Announcements;
            return View(announcement);
        }

        //[ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * Duyuru ekeleme
        [HttpGet]
        public IActionResult AddAnnouncements()
        {
            ViewData["Title"] = "Duyuru ekle";
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAnnouncementsAsync(Announcement announcement, IFormFile PicturePath)
        {

            // *  resim yolu
            if (PicturePath != null)
            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Announcements/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                announcement.PicturePath = path;

                announcement.PicturePath = announcement.PicturePath.Substring(announcement.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            announcement.AdditionDate = DateTime.Now;
            // announcement.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
            announcement.AddUserID = 2;
            // * resim wwwroot siliyoruz

            db.Announcements.Add(announcement);
            // Inner Join yapılacak
            db.SaveChanges();
            return RedirectToAction("Announcements");
        }
        // * Duyuru güncelleme
        [HttpGet]
        public IActionResult EditAnnouncements(int? id)
        {
            var foundAnnouncement = db.Announcements.Where(a => a.Id == id).FirstOrDefault();
            var languages = db.Language.ToList();
            ViewBag.languages = languages;
            return View(foundAnnouncement);
        }

        [HttpPost]
        public async Task<IActionResult> EditAnnouncementsAsync(int? id, Announcement announcement, IFormFile PicturePath)
        {


            var foundAnnouncement = db.Announcements.Where(a => a.Id == id).FirstOrDefault();
            foundAnnouncement.AdditionDate = DateTime.Now;
            foundAnnouncement.AddUserID = 2;
            foundAnnouncement.Title = announcement.Title;
            foundAnnouncement.Content = announcement.Content;
            foundAnnouncement.ShortText = announcement.ShortText;
            foundAnnouncement.Language = announcement.Language;

            // * resim yolu
            if (PicturePath != null)
            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Announcements/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                announcement.PicturePath = path;

                announcement.PicturePath = announcement.PicturePath.Substring(announcement.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            foundAnnouncement.PicturePath = announcement.PicturePath;

            db.Announcements.Update(foundAnnouncement);
            db.SaveChanges();
            return RedirectToAction("Announcements");
        }
        // * duyuru silme

        [HttpPost]
        public IActionResult DeleteAnnouncements(int id)
        {
            try
            {
                var foundAnnouncement = db.Announcements.Where(a => a.Id == id).FirstOrDefault();
                db.Announcements.Remove(foundAnnouncement);
                db.SaveChanges();
                return RedirectToAction("Announcements");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // * Genel Ayarlar
        [HttpGet]
        public IActionResult GenSettings()
        {
            var genSettings = db.GenSetting;
            ViewData["Title"] = "Genel Ayarlar";
            return View(genSettings);
        }

        //* Genel Ayar güncelleme

        [HttpGet]
        public IActionResult EditGenSettings(int? id)
        {
            var foundGenSettings = db.GenSetting.Where(a => a.Id == id).FirstOrDefault();
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            return View(foundGenSettings);
        }

        [HttpPost]
        public IActionResult EditGenSettings(int? id, GenSetting genSetting)
        {
            var defaultGenSettings = db.GenSetting.Where(gen => gen.Id == id).FirstOrDefault();
            defaultGenSettings.AddUserID = 2;
            defaultGenSettings.AdditionDate = DateTime.Now;
            defaultGenSettings.WebsiteName = genSetting.WebsiteName;
            defaultGenSettings.MetaAuthor = genSetting.MetaAuthor;
            defaultGenSettings.MetaKeyWords = genSetting.MetaKeyWords;
            defaultGenSettings.Facebook = genSetting.Facebook;
            defaultGenSettings.Twitter = genSetting.Twitter;
            defaultGenSettings.GooglePlus = genSetting.GooglePlus;
            defaultGenSettings.Instagram = genSetting.Instagram;
            defaultGenSettings.LinkedIn = genSetting.LinkedIn;
            defaultGenSettings.Youtube = genSetting.Youtube;
            defaultGenSettings.Telephone = genSetting.Telephone;
            defaultGenSettings.MetaDescription = genSetting.MetaDescription;
            defaultGenSettings.Email = genSetting.Email;
            defaultGenSettings.Fax = genSetting.Fax;
            defaultGenSettings.WebAddress = genSetting.WebAddress;
            defaultGenSettings.OrganizerID = 2;
            defaultGenSettings.IssueDate = DateTime.Now;
            defaultGenSettings.ShortHistory = genSetting.ShortHistory;
            defaultGenSettings.Address = genSetting.Address;
            defaultGenSettings.language = genSetting.language;
            db.GenSetting.Update(defaultGenSettings);
            db.SaveChanges();
            return View();
        }

        // * yönetim

        [HttpGet]
        public IActionResult Management()
        {
            var management = db.Management;
            ViewData["Title"] = "Yönetim";
            return View(management);
        }

        // * yönetim ekeleme
        [HttpGet]
        public IActionResult AddManagement()
        {
            ViewData["Title"] = "Yönetici Ekle";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddManagementAsync(Management management, IFormFile Picture)
        {
            // * resim yolu
            if (Picture != null)
            {
                string imageExtension = Path.GetExtension(Picture.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Management/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await Picture.CopyToAsync(stream);

                management.Picture = path;

                management.Picture = management.Picture.Substring(management.Picture.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            management.AddUserID = 2;
            management.AdditionDate = DateTime.Now;
            management.OrganizerID = 2;
            management.IssueDate = DateTime.Now;
            management.IsStaff = true;
            db.Management.Add(management);
            db.SaveChanges();
            return RedirectToAction("Management");
        }

        // * yönetim güncelleme
        [HttpGet]
        public IActionResult EditManagement(int? id)
        {
            var foundManagement = db.Management.Where(a => a.Id == id).FirstOrDefault();
            return View(foundManagement);
        }

        [HttpPost]
        public async Task<IActionResult> EditManagementAsync(int? id, Management management, IFormFile Picture)
        {
            var foundManagement = db.Management.Where(a => a.Id == id).FirstOrDefault();
            foundManagement.FullName = management.FullName;
            foundManagement.Email = management.Email;

            foundManagement.Link = management.Link;
            foundManagement.Status = management.Status;
            foundManagement.Queue = management.Queue;
            foundManagement.StaffStatus = management.StaffStatus;

            // * resim yolu
            if (Picture != null)

            {
                string imageExtension = Path.GetExtension(Picture.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Management/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await Picture.CopyToAsync(stream);

                management.Picture = path;

                management.Picture = management.Picture.Substring(management.Picture.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            foundManagement.Picture = management.Picture;

            db.Management.Update(foundManagement);
            db.SaveChanges();
            return RedirectToAction("Management");
        }

        // * yönetim silme

        [HttpPost]
        public IActionResult DeleteManagement(int id)
        {
            try
            {
                var foundManagement = db.Management.Where(a => a.Id == id).FirstOrDefault();
                db.Management.Remove(foundManagement);
                db.SaveChanges();
                return RedirectToAction("Management");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // * kullanıcılar

        [HttpGet]
        public IActionResult Users()
        {
            var users = db.Users;
            ViewData["Title"] = "Kullanıcılar";
            return View(users);
        }

        // * Kullanıcı ekle
        [HttpGet]
        public IActionResult AddUsers()
        {
            // * role 
            var roles = db.Role.ToList();
            ViewBag.roles = roles;

            ViewData["Title"] = "Kullanıcı Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUsersAsync(Users user, IFormFile PicturePath)
        {


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



            user.AdditionDate = DateTime.Now;
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        // * Kullanıcı Güncelleme

        [HttpGet]
        public IActionResult EditUsers(int? id)
        {

            // * role 
            var roles = db.Role.ToList();
            ViewBag.roles = roles;

            var foundUser = db.Users.Where(user => user.UserID == id).FirstOrDefault();
            return View(foundUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersAsync(int? id, Users user, IFormFile PicturePath)
        {
            var foundUser = db.Users.Where(user => user.UserID == id).FirstOrDefault();
            foundUser.Name = user.Name;
            foundUser.Surname = user.Surname;
            foundUser.Institution = user.Institution;
            foundUser.Password = user.Password;
            foundUser.Email = user.Email;

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
            foundUser.AdditionDate = DateTime.Now;
            foundUser.Role = user.Role;
            db.Users.Update(foundUser);
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        [HttpPost]
        public IActionResult DeleteUser(int? id)
        {
            var foundUser = db.Users.Where(user => user.UserID == id).FirstOrDefault();
            db.Users.Remove(foundUser);
            db.SaveChanges();
            return RedirectToAction("Users");
        }


        // * altyapi

        [HttpGet]
        public IActionResult Substructure()
        {
            var substructure = db.Substructure;
            ViewData["Title"] = "Altyapı";
            return View(substructure);
        }

        // * altyapi ekle

        [HttpGet]
        public IActionResult AddSubstructure()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Altyapı Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSubstructureAsync(Substructure substructure, IFormFile PicturePath)
        {
            substructure.AddUserID = 2;
            substructure.AdditionDate = DateTime.Now;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Substructure/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                substructure.PicturePath = path;

                substructure.PicturePath = substructure.PicturePath.Substring(substructure.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }


            db.Substructure.Add(substructure);
            db.SaveChanges();
            return RedirectToAction("Substructure");
        }

        [HttpGet]
        public IActionResult EditSubstructure(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundSubstructure = db.Substructure.Where(subs => subs.Id == id).FirstOrDefault();
            return View(foundSubstructure);
        }

        [HttpPost]
        public async Task<IActionResult> EditSubstructureAsync(int? id, Substructure substructure, IFormFile PicturePath)
        {
            var foundSubstructure = db.Substructure.Where(subs => subs.Id == id).FirstOrDefault();
            foundSubstructure.Name = substructure.Name;
            foundSubstructure.Description = substructure.Description;
            foundSubstructure.AddUserID = 2;
            foundSubstructure.AdditionDate = DateTime.Now;
            foundSubstructure.Language = substructure.Language;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Substructure/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                substructure.PicturePath = path;

                substructure.PicturePath = substructure.PicturePath.Substring(substructure.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }


            foundSubstructure.PicturePath = substructure.PicturePath;
            db.Substructure.Update(foundSubstructure);
            db.SaveChanges();
            return RedirectToAction("Substructure");
        }

        [HttpPost]
        public IActionResult DeleteSubstructure(int? id)
        {
            var foundSubstructure = db.Substructure.Where(subs => subs.Id == id).FirstOrDefault();
            db.Substructure.Remove(foundSubstructure);
            db.SaveChanges();
            return RedirectToAction("Substructure");
        }

        // * haberler

        [HttpGet]
        public IActionResult News()
        {
            var news = db.News;
            ViewData["Title"] = "Haberler";
            return View(news);
        }

        // * haber ekle

        [HttpGet]
        public IActionResult AddNews()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Haber Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewsAsync(News news, IFormFile PicturePath)
        {
            news.AddUserID = 2;
            news.AdditionDate = DateTime.Now;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/News/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                news.PicturePath = path;

                news.PicturePath = news.PicturePath.Substring(news.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }


            db.News.Add(news);
            db.SaveChanges();
            return RedirectToAction("News");
        }

        // * haber güncelleme

        [HttpGet]
        public IActionResult EditNews(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundNews = db.News.Where(news => news.Id == id).FirstOrDefault();
            return View(foundNews);
        }

        [HttpPost]
        public async Task<IActionResult> EditNewsAsync(int? id, News news, IFormFile PicturePath)
        {
            var foundNews = db.News.Where(news => news.Id == id).FirstOrDefault();
            foundNews.Title = news.Title;
            foundNews.Content = news.Content;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/News/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                news.PicturePath = path;

                news.PicturePath = news.PicturePath.Substring(news.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            foundNews.PicturePath = news.PicturePath;


            foundNews.AddUserID = 2;
            foundNews.AdditionDate = DateTime.Now;
            foundNews.Language = news.Language;
            foundNews.ShortText = news.ShortText;
            db.News.Update(foundNews);
            db.SaveChanges();
            return RedirectToAction("News");
        }

        [HttpPost]
        public IActionResult DeleteNews(int? id)
        {
            var foundNews = db.News.Where(news => news.Id == id).FirstOrDefault();
            db.News.Remove(foundNews);
            db.SaveChanges();
            return RedirectToAction("News");
        }

        // * makaleler

        [HttpGet]
        public IActionResult Articles()
        {
            var articles = db.Articles;
            ViewData["Title"] = "Makaleler";
            return View(articles);
        }

        [HttpGet]
        public IActionResult AddArticles()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Makale Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddArticlesAsync(Articles articles, IFormFile PicturePath)
        {
            articles.AddUserID = 2;
            articles.AdditionDate = DateTime.Now;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Articles/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                articles.PicturePath = path;

                articles.PicturePath = articles.PicturePath.Substring(articles.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            db.Articles.Add(articles);


            db.SaveChanges();
            return RedirectToAction("Articles");
        }
        [HttpGet]
        public IActionResult EditArticles(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundArticle = db.Articles.Where(article => article.Id == id).FirstOrDefault();
            return View(foundArticle);
        }

        [HttpPost]
        public async Task<IActionResult> EditArticlesAsync(int? id, Articles articles, IFormFile PicturePath)
        {
            var foundArticle = db.Articles.Where(article => article.Id == id).FirstOrDefault();
            foundArticle.Name = articles.Name;
            foundArticle.Description = articles.Description;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Articles/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                articles.PicturePath = path;

                articles.PicturePath = articles.PicturePath.Substring(articles.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }


            foundArticle.PicturePath = articles.PicturePath;
            foundArticle.AddUserID = 2;
            foundArticle.AdditionDate = foundArticle.AdditionDate;
            foundArticle.Language = articles.Language;

            db.Articles.Update(foundArticle);
            db.SaveChanges();

            return RedirectToAction("Articles");
        }

        [HttpPost]
        public IActionResult DeleteArticle(int? id)
        {
            var foundArticle = db.Articles.Where(article => article.Id == id).FirstOrDefault();
            db.Articles.Remove(foundArticle);
            db.SaveChanges();
            return RedirectToAction("Articles");
        }

        // * bildiriler

        [HttpGet]
        public IActionResult Notifications()
        {
            var notifications = db.Notification;
            ViewData["Title"] = "Bildiriler";
            return View(notifications);
        }
        // * ekle
        [HttpGet]
        public IActionResult AddNotification()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Bildiri Ekle";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddNotificationAsync(Notification notification, IFormFile PicturePath)
        {
            notification.AddUserID = 2;
            notification.AdditionDate = DateTime.Now;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Notification/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                notification.PicturePath = path;

                notification.PicturePath = notification.PicturePath.Substring(notification.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            db.Notification.Add(notification);
            db.SaveChanges();
            return RedirectToAction("Notifications");
        }

        [HttpGet]
        public IActionResult EditNotification(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundNotification = db.Notification.Where(notification => notification.Id == id).FirstOrDefault();
            return View(foundNotification);
        }

        [HttpPost]
        public async Task<IActionResult> EditNotificationAsync(int? id, Notification notification, IFormFile PicturePath)
        {
            var foundNotification = db.Notification.Where(notification => notification.Id == id).FirstOrDefault();
            foundNotification.Name = notification.Name;
            foundNotification.Description = notification.Description;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Notification/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                notification.PicturePath = path;

                notification.PicturePath = notification.PicturePath.Substring(notification.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }


            foundNotification.PicturePath = notification.PicturePath;
            foundNotification.Language = notification.Language;
            foundNotification.AdditionDate = DateTime.Now; // * aynı format olacak
            foundNotification.AddUserID = 2;

            db.Notification.Update(foundNotification);
            db.SaveChanges();

            return RedirectToAction("Notifications");
        }

        [HttpPost]
        public IActionResult DeleteNotification(int? id)
        {
            var foundNotification = db.Notification.Where(notification => notification.Id == id).FirstOrDefault();
            db.Notification.Remove(foundNotification);
            db.SaveChanges();

            return RedirectToAction("Notifications");
        }

        // * Projeler

        [HttpGet]
        public IActionResult Projects()
        {
            var projects = db.Projects;
            ViewData["Title"] = "Projeler";
            return View(projects);
        }

        // * ekle

        [HttpGet]
        public IActionResult AddProject()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Proje Ekle";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddProjectAsync(Project project, IFormFile PicturePath)
        {
            project.AddUserID = 2;
            project.AdditionDate = DateTime.Now;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Projects/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                project.PicturePath = path;

                project.PicturePath = project.PicturePath.Substring(project.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }


            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Projects");
        }

        // * güncelleme
        [HttpGet]
        public IActionResult EditProject(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundProject = db.Projects.Where(project => project.Id == id).FirstOrDefault();
            return View(foundProject);
        }

        [HttpPost]
        public async Task<IActionResult> EditProjectAsync(int? id, Project project, IFormFile PicturePath)
        {
            var foundProject = db.Projects.Where(project => project.Id == id).FirstOrDefault();

            foundProject.Name = project.Name;
            foundProject.Description = project.Description;


            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Projects/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                project.PicturePath = path;

                project.PicturePath = project.PicturePath.Substring(project.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }



            foundProject.PicturePath = project.PicturePath;
            foundProject.AddUserID = 2;
            foundProject.AdditionDate = DateTime.Now;
            foundProject.Language = project.Language;

            db.Projects.Update(foundProject);
            db.SaveChanges();

            return RedirectToAction("Projects");
        }

        // * silme

        [HttpPost]
        public IActionResult DeleteProject(int? id)
        {
            var foundProject = db.Projects.Where(project => project.Id == id).FirstOrDefault();

            db.Projects.Remove(foundProject);
            db.SaveChanges();

            return RedirectToAction("Projects");
        }
    }
}