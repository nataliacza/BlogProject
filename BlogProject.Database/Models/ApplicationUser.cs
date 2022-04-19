using Microsoft.AspNetCore.Identity;

namespace BlogProject.Database.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual IQueryable<Post> Posts { get; set; }
}
