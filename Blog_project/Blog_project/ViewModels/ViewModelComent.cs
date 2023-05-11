using Blog_project.Models;

namespace Blog_project.ViewModels
{
    public class ViewModelComent
    {

        public Post post { get; set; }
        public User user { get; set; }
        public IEnumerable<User>? Users { get; set; }
        public IEnumerable<Coment>? Coments { get; set; }

        public ViewModelComent(Post post,User user, IEnumerable<User>? users, IEnumerable<Coment>? coments)
        {
            this.post = post;
            this.user = user;
            Users = users;
            Coments = coments;
        }
    }
}
