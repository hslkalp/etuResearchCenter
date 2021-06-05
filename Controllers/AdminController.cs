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

        private int logedUserID;

        public AdminController(ETURContext context)
        {
            db = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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


        // * giriş işlemi
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

                    // * giriş yapan kişi id eşitlendi
                    logedUserID = (int)HttpContext.Session.GetInt32("User_ID");

                    return Json(new { Result = true, Message = "Başarıyla Giriş Yaptınız. Yönlendiriliyorsunuz..", Url = "/Admin/Home" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = false, Message = ex.Message });

            }
        }

        // * çıkış işlemi
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult logOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }



        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * Duyurular
        public IActionResult Announcements()
        {
            ViewData["Title"] = "Duyurular";
            var announcement = db.Announcements;
            return View(announcement);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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

            announcement.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");

            db.Announcements.Add(announcement);
            db.SaveChanges();

            return RedirectToAction("Announcements");
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * Duyuru güncelleme
        [HttpGet]
        public IActionResult EditAnnouncements(int? id)
        {
            var foundAnnouncement = db.Announcements.Where(a => a.Id == id).FirstOrDefault();
            var languages = db.Language.ToList();
            ViewBag.languages = languages;
            return View(foundAnnouncement);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> EditAnnouncementsAsync(int? id, Announcement announcement, IFormFile PicturePath)
        {


            var foundAnnouncement = db.Announcements.Where(a => a.Id == id).FirstOrDefault();
            foundAnnouncement.AdditionDate = DateTime.Now;
            foundAnnouncement.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
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


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * Genel Ayarlar
        [HttpGet]
        public IActionResult GenSettings()
        {
            var genSettings = db.GenSetting;
            ViewData["Title"] = "Genel Ayarlar";
            return View(genSettings);
        }



        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        //* Genel Ayar güncelleme
        [HttpGet]
        public IActionResult EditGenSettings(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundGenSettings = db.GenSetting.Where(a => a.Id == id).FirstOrDefault();
            return View(foundGenSettings);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult EditGenSettings(int? id, GenSetting genSetting)
        {
            var defaultGenSettings = db.GenSetting.Where(gen => gen.Id == id).FirstOrDefault();
            defaultGenSettings.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
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
            defaultGenSettings.OrganizerID = (int)HttpContext.Session.GetInt32("User_ID");
            defaultGenSettings.IssueDate = DateTime.Now;
            defaultGenSettings.ShortHistory = genSetting.ShortHistory;
            defaultGenSettings.Address = genSetting.Address;
            defaultGenSettings.Language = genSetting.Language;

            db.GenSetting.Update(defaultGenSettings);
            db.SaveChanges();
            return View();
        }

        // * yönetim
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult Management()
        {
            var management = db.Management;
            ViewData["Title"] = "Yönetim";
            return View(management);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * yönetim ekeleme
        [HttpGet]
        public IActionResult AddManagement()
        {
            // * aktif ayarları
            var isActive = db.IsActive.ToList();
            ViewBag.isActive = isActive;

            ViewData["Title"] = "Yönetici Ekle";
            return View();
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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

            management.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
            management.AdditionDate = DateTime.Now;
            management.OrganizerID = (int)HttpContext.Session.GetInt32("User_ID");
            management.IssueDate = DateTime.Now;
            db.Management.Add(management);
            db.SaveChanges();
            return RedirectToAction("Management");
        }

        // * yönetim güncelleme
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult EditManagement(int? id)
        {
            // * aktif ayarları
            var isActive = db.IsActive.ToList();
            ViewBag.isActive = isActive;

            var foundManagement = db.Management.Where(a => a.Id == id).FirstOrDefault();
            return View(foundManagement);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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
            foundManagement.IsStaff = management.IsStaff;
            foundManagement.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
            foundManagement.OrganizerID = (int)HttpContext.Session.GetInt32("User_ID");
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * kullanıcılar
        [HttpGet]
        public IActionResult Users()
        {
            var users = db.Users;
            ViewData["Title"] = "Kullanıcılar";
            return View(users);
        }


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult DeleteUser(int? id)
        {
            var foundUser = db.Users.Where(user => user.UserID == id).FirstOrDefault();
            db.Users.Remove(foundUser);
            db.SaveChanges();
            return RedirectToAction("Users");
        }


        // * altyapi
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult Substructure()
        {
            var substructure = db.Substructure;
            ViewData["Title"] = "Altyapı";
            return View(substructure);
        }

        // * altyapi ekle
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult AddSubstructure()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Altyapı Ekle";
            return View();
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddSubstructureAsync(Substructure substructure, IFormFile PicturePath)
        {
            substructure.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult EditSubstructure(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundSubstructure = db.Substructure.Where(subs => subs.Id == id).FirstOrDefault();
            return View(foundSubstructure);
        }


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> EditSubstructureAsync(int? id, Substructure substructure, IFormFile PicturePath)
        {
            var foundSubstructure = db.Substructure.Where(subs => subs.Id == id).FirstOrDefault();
            foundSubstructure.Name = substructure.Name;
            foundSubstructure.Description = substructure.Description;
            foundSubstructure.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
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


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult DeleteSubstructure(int? id)
        {
            var foundSubstructure = db.Substructure.Where(subs => subs.Id == id).FirstOrDefault();
            db.Substructure.Remove(foundSubstructure);
            db.SaveChanges();
            return RedirectToAction("Substructure");
        }

        // * haberler


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult News()
        {
            var news = db.News;
            ViewData["Title"] = "Haberler";
            return View(news);
        }

        // * haber ekle
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult AddNews()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Haber Ekle";
            return View();
        }


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddNewsAsync(News news, IFormFile PicturePath)
        {
            news.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
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
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult EditNews(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundNews = db.News.Where(news => news.Id == id).FirstOrDefault();
            return View(foundNews);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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
            foundNews.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
            foundNews.AdditionDate = DateTime.Now;
            foundNews.Language = news.Language;
            foundNews.ShortText = news.ShortText;

            db.News.Update(foundNews);
            db.SaveChanges();

            return RedirectToAction("News");
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult DeleteNews(int? id)
        {
            var foundNews = db.News.Where(news => news.Id == id).FirstOrDefault();
            db.News.Remove(foundNews);
            db.SaveChanges();
            return RedirectToAction("News");
        }

        // * makaleler
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult Articles()
        {
            int AddUserID = (int)HttpContext.Session.GetInt32("User_ID");

            var articles = db.Articles.Where(articles => articles.AddUserID == AddUserID);

            ViewData["Title"] = "Makaleler";
            return View(articles);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult AddArticles()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Makale Ekle";
            return View();
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddArticlesAsync(Articles articles, IFormFile PicturePath)
        {
            articles.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult EditArticles(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundArticle = db.Articles.Where(article => article.Id == id).FirstOrDefault();
            return View(foundArticle);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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
            foundArticle.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
            foundArticle.AdditionDate = foundArticle.AdditionDate;
            foundArticle.Language = articles.Language;

            db.Articles.Update(foundArticle);
            db.SaveChanges();

            return RedirectToAction("Articles");
        }


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult DeleteArticle(int? id)
        {
            var foundArticle = db.Articles.Where(article => article.Id == id).FirstOrDefault();
            db.Articles.Remove(foundArticle);
            db.SaveChanges();
            return RedirectToAction("Articles");
        }

        // * bildiriler
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult Notifications()
        {
            int AddUserID = (int)HttpContext.Session.GetInt32("User_ID");

            var notifications = db.Notification.Where(notifications => notifications.AddUserID == AddUserID);

            ViewData["Title"] = "Bildiriler";
            return View(notifications);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddNotificationAsync(Notification notification, IFormFile PicturePath)
        {
            notification.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
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


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult EditNotification(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            var foundNotification = db.Notification.Where(notification => notification.Id == id).FirstOrDefault();
            return View(foundNotification);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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
            foundNotification.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");

            db.Notification.Update(foundNotification);
            db.SaveChanges();

            return RedirectToAction("Notifications");
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult DeleteNotification(int? id)
        {
            var foundNotification = db.Notification.Where(notification => notification.Id == id).FirstOrDefault();
            db.Notification.Remove(foundNotification);
            db.SaveChanges();

            return RedirectToAction("Notifications");
        }

        // * Projeler
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult Projects()
        {
            int AddUserID = (int)HttpContext.Session.GetInt32("User_ID");

            var projects = db.Projects.Where(projects => projects.AddUserID == AddUserID);

            ViewData["Title"] = "Projeler";
            return View(projects);
        }

        // * ekle
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult AddProject()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            ViewData["Title"] = "Proje Ekle";
            return View();
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddProjectAsync(Project project, IFormFile PicturePath)
        {
            project.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
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
            foundProject.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
            foundProject.AdditionDate = DateTime.Now;
            foundProject.Language = project.Language;

            db.Projects.Update(foundProject);
            db.SaveChanges();

            return RedirectToAction("Projects");
        }


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * silme

        [HttpPost]
        public IActionResult DeleteProject(int? id)
        {
            var foundProject = db.Projects.Where(project => project.Id == id).FirstOrDefault();

            db.Projects.Remove(foundProject);
            db.SaveChanges();

            return RedirectToAction("Projects");
        }

        // * laboratuvar
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult labs()
        {
            ViewData["Title"] = "Laboratuvarlar";
            var labs = db.Labs;
            return View(labs);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * laboratuvar ekle
        [HttpGet]
        public IActionResult AddLab()
        {
            ViewData["Title"] = "Laboratuvar Ekle";
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            // * altyapı ayarları

            var substructure = db.Substructure.ToList();
            ViewBag.substructure = substructure;

            return View();
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddLabAsync(Labs labs, IFormFile PicturePath)
        {

            labs.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
            labs.AdditionDate = DateTime.Now;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Labs/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                labs.PicturePath = path;

                labs.PicturePath = labs.PicturePath.Substring(labs.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            db.Labs.Add(labs);
            db.SaveChanges();



            return RedirectToAction("Labs");
        }


        // *laboratuvar güncelleme
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult EditLab(int? id)
        {

            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            // * altyapı ayarları

            var substructure = db.Substructure.ToList();
            ViewBag.substructure = substructure;


            var foundLab = db.Labs.Where(labs => labs.Id == id).FirstOrDefault();
            return View(foundLab);
        }


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> EditLabAsync(int? id, Labs labs, IFormFile PicturePath)
        {

            var foundLab = db.Labs.Where(labs => labs.Id == id).FirstOrDefault();

            foundLab.Name = labs.Name;
            foundLab.Description = labs.Description;
            foundLab.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");
            foundLab.AdditionDate = DateTime.Now;
            foundLab.Language = labs.Language;
            foundLab.SubstructureID = labs.SubstructureID;

            // * resim yolu
            if (PicturePath != null)

            {
                string imageExtension = Path.GetExtension(PicturePath.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Labs/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await PicturePath.CopyToAsync(stream);

                labs.PicturePath = path;

                labs.PicturePath = labs.PicturePath.Substring(labs.PicturePath.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            foundLab.PicturePath = labs.PicturePath;

            db.Labs.Update(foundLab);
            db.SaveChanges();

            return RedirectToAction("Labs");
        }


        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult DeleteLab(int? id)
        {
            var foundLab = db.Labs.Where(labs => labs.Id == id).FirstOrDefault();

            db.Labs.Remove(foundLab);
            db.SaveChanges();

            return RedirectToAction("Labs");
        }

        // * slider

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult Slider()
        {
            ViewData["Title"] = "Slider";
            var slider = db.Slider;
            return View(slider);
        }

        // * ekle
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpGet]
        public IActionResult AddSlider()
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            // * aktif ayarları
            var isActive = db.IsActive.ToList();
            ViewBag.isActive = isActive;

            ViewData["Title"] = "Slider Ekle";

            return View();
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> AddSliderAsync(Slider slider, IFormFile Picture)
        {
            slider.AdditionDate = DateTime.Now;
            slider.AddUserID = (int)HttpContext.Session.GetInt32("User_ID");

            // * resim yolu
            if (Picture != null)

            {
                string imageExtension = Path.GetExtension(Picture.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Slider/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await Picture.CopyToAsync(stream);

                slider.Picture = path;

                slider.Picture = slider.Picture.Substring(slider.Picture.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            db.Slider.Add(slider);
            db.SaveChanges();

            return RedirectToAction("Slider");
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        // * güncelle slider
        [HttpGet]
        public IActionResult EditSlider(int? id)
        {
            // * dil ayarları
            var languages = db.Language.ToList();
            ViewBag.languages = languages;

            // * aktif ayarları
            var isActive = db.IsActive.ToList();
            ViewBag.isActive = isActive;

            var foundSlider = db.Slider.Where(slider => slider.Id == id).FirstOrDefault();
            return View(foundSlider);
        }

        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public async Task<IActionResult> EditSliderAsync(int? id, Slider slider, IFormFile Picture)
        {

            var foundSlider = db.Slider.Where(slider => slider.Id == id).FirstOrDefault();

            foundSlider.AdditionDate = DateTime.Now;
            foundSlider.AddUserID = (int)HttpContext.Session.GetInt32("User_ID"); ;

            // * resim yolu
            if (Picture != null)

            {
                string imageExtension = Path.GetExtension(Picture.FileName);

                string imageName = Guid.NewGuid() + imageExtension;

                string path = Path.Combine($"wwwroot/img/Slider/{imageName}");

                using var stream = new FileStream(path, FileMode.Create);

                await Picture.CopyToAsync(stream);

                slider.Picture = path;

                slider.Picture = slider.Picture.Substring(slider.Picture.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);

            }

            foundSlider.Picture = slider.Picture;
            foundSlider.Description = slider.Description;
            foundSlider.Title = slider.Title;
            foundSlider.SubTitle = slider.SubTitle;
            foundSlider.Language = slider.Language;
            foundSlider.Queue = slider.Queue;
            foundSlider.IsActive = slider.IsActive;
            foundSlider.Link = slider.Link;

            db.Slider.Update(foundSlider);
            db.SaveChanges();


            return RedirectToAction("Slider");
        }

        //* slider silme
        [ServiceFilter(typeof(AdminUserSecurityAttribute))]
        [HttpPost]
        public IActionResult DeleteSlider(int? id)
        {
            var foundSlider = db.Slider.Where(slider => slider.Id == id).FirstOrDefault();

            db.Slider.Remove(foundSlider);
            db.SaveChanges();

            return RedirectToAction("Slider");
        }



    }// * admin controller end
}// * controller end