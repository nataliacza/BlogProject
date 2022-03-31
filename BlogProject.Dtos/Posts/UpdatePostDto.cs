using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Dtos.Posts
{
    public class UpdatePostDto
    {
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }
    }
}
