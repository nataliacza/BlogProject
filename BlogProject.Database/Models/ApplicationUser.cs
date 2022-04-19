using Microsoft.AspNetCore.Identity;

namespace BlogProject.Database.Models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    // better implementation, but issue with getting posts from db - check LINQ EfPostGetter:
    // public virtual IQueryable<Post> Posts { get; set; }
    public virtual IEnumerable<Post> Posts { get; set; }
}
