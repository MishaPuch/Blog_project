using Blog_project.Models;
using Blog_project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Web;



namespace Blog_project.Controllers
{
    public class CreateAccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        User ? user = new User();
        [HttpPost]
        public async Task<ActionResult> Index(string name,string email, string password, string confirmPassword)
        {
            using (BlogContext db = new BlogContext())
            {
                if (password == confirmPassword)
                {

                    user.Id = db.Users.Count() + 1;
                    user.Name = name;
                    user.Email = email;
                    user.Password = password;
                    user.Coments = null;
                    user.Posts = null;

                    db.Users.Add(user);
                    db.SaveChanges();

                    HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(user));

                    return await Task.FromResult(new RedirectToActionResult("Index", "Home", null));

                }

                else
                {
                    return View();
                }
            }
        }

        
    }
}
