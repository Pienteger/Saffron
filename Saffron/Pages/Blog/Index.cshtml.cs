using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Saffron.DataContext;
using Saffron.Services.BlogServices;
using SaffronEngine.Blog;

namespace Saffron.Pages.Blog
{
    public class IndexModel : PageModel
    {
        private readonly IBlogService blogService;

        public IndexModel(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        [BindProperty]
        public IEnumerable<BlogPost> BlogPosts { get; set; }

        public void OnGet(string startPage, string itemCount, string tag, string category)
        {
            int start, count;
            try
            {
                start = string.IsNullOrWhiteSpace(startPage) ? 0 : int.Parse(startPage);
            }
            catch (Exception)
            {
                start = 0;
            }
            try
            {
                count = string.IsNullOrWhiteSpace(startPage) ? 10 : Math.Abs(int.Parse(itemCount));
            }
            catch (Exception)
            {
                count = 10;
            }

            BlogPosts = blogService.GetPosts(start, count);
        }
    }
}
