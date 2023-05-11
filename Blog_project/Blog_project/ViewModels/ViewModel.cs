using Blog_project.Models;
using Newtonsoft.Json;

namespace Blog_project.ViewModels
{
    public class ViewModel
    
    {

        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<User>? Users { get; set; }
        public IEnumerable<Coment>? Coments { get; set; }

        public ViewModel( IEnumerable<Post> posts, IEnumerable<User>? users, IEnumerable<Coment>? coments)
        {
            Posts = posts;
            Users = users;
            Coments = coments;
        }

    }
   

}

