using Blog_project.Models;
using Blog_project.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog_project.Controllers
{
    public class LoginController : Controller
    {
        

        [HttpGet]
        public ActionResult Login()
        {
            using (BlogContext db = new BlogContext())
            {
                var users = db.Users.ToList();
                return View(users);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Login(string email, string password)
        {
            using (BlogContext db = new BlogContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(user));

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(user);
                }
            }

        }
        public ActionResult logout()
        {
            using (BlogContext db = new BlogContext())
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Index", "Home");


            }
        }


    }
}
