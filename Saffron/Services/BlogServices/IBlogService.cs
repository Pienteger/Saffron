using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaffronEngine.Blog;

namespace Saffron.Services.BlogServices
{
    public interface IBlogService
    {
        void Add(BlogPost blog);
        BlogPost GetPost(string slug);
        IEnumerable<BlogPost> GetPosts(int startRange, int count = 10);
        IEnumerable<PostCategory> GetCategories();
        IEnumerable<PostTag> GetTags();
    }
}
