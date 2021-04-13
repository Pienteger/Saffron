using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SaffronEngine.Blog;
using Saffron.DataContext;

namespace Saffron.Services.BlogServices
{
    public class BlogService : IBlogService
    {
        private readonly SaffronContext context;

        public BlogService(SaffronContext context)
        {
            this.context = context;
        }
        public void Add(BlogPost blog)
        {
            blog.Slug = string.Join('-', blog.Title.Split(' ')).ToLower();
            context.BlogPosts.Add(blog);
            context.SaveChanges();
        }

        public BlogPost GetPost(string slug)
        {
            return context.BlogPosts.FirstOrDefault(x => EF.Functions.Like(x.Slug, slug));
        }

        public IEnumerable<BlogPost> GetPosts(int startRange, int count = 10)
        {
            return context.BlogPosts.OrderByDescending(x => x.Created)
                .Skip(startRange).Take(count).ToList();
        }
    }
}
