using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Dtos.Posts
{
    public class CreatePostDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}
