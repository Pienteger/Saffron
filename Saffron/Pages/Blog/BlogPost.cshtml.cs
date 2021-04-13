using SaffronEngine.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Saffron.Services.BlogServices;
using Saffron.Services.CoreServices;

namespace Saffron.Pages.Blog
{
    public class BlogPostModel : PageModel
    {
        private readonly IBlogService blogService;
        private readonly UtilityService utility;

        public BlogPostModel(IBlogService blogService, UtilityService utility)
        {
            this.blogService = blogService;
            this.utility = utility;
        }

        [BindProperty]
        public BlogPost Blog { get; set; }
        [BindProperty]
        public bool HasPost { get; set; }
        public void OnGet(string slug)
        {
            Blog = blogService.GetPost(slug);
            if (Blog == null) return;
            utility.ModifiedTime = Blog.Modified;
            HasPost = true;
        }
    }
}
