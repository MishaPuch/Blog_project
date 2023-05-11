using System;
using System.Collections.Generic;

namespace Blog_project.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Coment> Coments { get; set; } = new List<Coment>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
