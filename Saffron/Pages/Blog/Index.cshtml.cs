using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Saffron.Pages.Blog
{
    public class IndexModel : PageModel
    {
        [BindProperty] public string Page { get; set; }
        public void OnGet(string page)
        {
            Page = page;
        }
    }
}
