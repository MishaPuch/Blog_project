using System;
using System.Collections.Generic;

namespace Blog_project.Models;

public partial class Coment
{
    public int Id { get; set; }

    public string? comentBody { get; set; }

    public int? UserId { get; set; }
   
    public int PostId { get; set; }


}
