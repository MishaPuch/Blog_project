using System;
using System.Collections.Generic;

namespace Blog_project.Models;

public partial class Post
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? PostTitle { get; set; }

    public string? PostBody { get; set; }

  
}
