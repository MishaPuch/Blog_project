using Blog_project.Hubs;
using Blog_project.Models;
using Blog_project.ViewModels;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Web;



namespace Blog_project.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()

        {            
            return View("Index", ViewModel());                      

        }




        [HttpPost]
        public async Task<ActionResult> Index(string Title, string postBody)
        {
            if (postBody != null)
            {
                User? user = null;
                if (HttpContext.Session.GetString("CurrentUser") != null)
                {
                    user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
                }

                using (BlogContext db = new BlogContext())
                {
                    Post post = new Post();
                    post.Id = db.Posts.Count() + 1;
                    post.UserId = user.Id;
                    post.PostTitle = Title;
                    post.PostBody = postBody;

                    db.Posts.Add(post);
                    db.SaveChanges();


                }
            }

            return RedirectToAction("Index");
        }



        [NonAction]
        public ViewModel ViewModel()
        {
            using (BlogContext db = new BlogContext())
            {
                // Получаем текущую сессию
                User? user = null;
                if (HttpContext.Session.GetString("CurrentUser") != null)
                {
                    user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));
                }
                

                // Записываем пользователя в сессию

                IEnumerable<Post> posts = db.Posts.ToList();
                IEnumerable<User> users = db.Users.ToList();
                IEnumerable<Coment> coments = db.Coments.ToList();

                ViewModel viewModel = new ViewModel(posts, users, coments);
                return viewModel;
            }
        }
        //public ActionResult ReadMore(ViewModelComent viewModel)
        
          //  return  View(viewModel);
        
        public ActionResult ReadMore(int id)
        {
            if (id != 0)
            {
                using (BlogContext db = new BlogContext())
                {

                    Post post = db.Posts.Find(id);
                    User user = db.Users.FirstOrDefault(x => x.Id == post.UserId);
                    IEnumerable<User> users = db.Users.ToList();
                    IEnumerable<Coment> coments = db.Coments.ToList();

                    ViewModelComent viewModel = new ViewModelComent(post, user, users, coments);

                    return View(viewModel);
                    //return await Task.FromResult(RedirectToAction("ReadMore", viewModel));
                }
                
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<ActionResult> ReadMore(int id, string coment)
        {
            User? user = null;
            if (HttpContext.Session.GetString("CurrentUser") != null)
            {
                user = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("CurrentUser"));


                using (BlogContext db = new BlogContext())
                {
                    Coment coment1 = new Coment();
                    coment1.Id = db.Coments.Count() + 1;
                    coment1.comentBody = coment;
                    coment1.UserId = user.Id;
                    coment1.PostId= id;
                    
                   

                    db.Coments.Add(coment1);
                    db.SaveChanges();

                }
                
            }
            return RedirectToAction("ReadMore", id);

        }
    }

}


