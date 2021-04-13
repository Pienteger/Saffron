using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SaffronEngine.Blog
{
    public class BlogPost
    {
        private string slug;

        public BlogPost()
        {

        }

        public Guid Id { get; set; }
        [Required]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

        public string FeaturedImage { get; set; }

        public DateTime Created { get; set; } = DateTime.Today;
        public DateTime Modified { get; set; } = DateTime.Today;
        public List<PostTag> PostTags { get; set; }
        public List<PostCategory> Categories { get; set; }
    }
}
