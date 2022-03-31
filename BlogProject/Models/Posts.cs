﻿using System.ComponentModel.DataAnnotations;

namespace BlogProject.Models
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string Author { get; set; }
    }
}