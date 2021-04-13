using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SaffronEngine.Blog;
using Saffron.Services.BlogServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using Saffron.Services.CoreServices;
using Microsoft.AspNetCore.Hosting;
using Syncfusion.EJ2.Inputs;
using Syncfusion.EJ2.RichTextEditor;

namespace Saffron.Pages.Blog
{
    public class AddBlogModel : PageModel
    {
        private readonly IBlogService blogService;
        private readonly IWebHostEnvironment hostingEnv;
        private readonly NavigationService navigation;

        public AddBlogModel(IBlogService blogService, IWebHostEnvironment env, NavigationService navigation)
        {
            this.blogService = blogService;
            hostingEnv = env;
            this.navigation = navigation;
        }
        [BindProperty]
        public BlogPost Blog { get; set; }
        [BindProperty] public string[] RichToolBar { get; set; }
        [BindProperty] public object AjaxSettings { get; set; }
        [BindProperty] public UploaderAsyncSettings AsyncSettings { get; set; }
        public void OnGet()
        {
            Blog = new();
            RichToolBar = new[]
            {
                "Bold", "Italic", "Underline", "StrikeThrough",
                "FontName", "FontSize", "FontColor", "BackgroundColor",
                "LowerCase", "UpperCase", "|",
                "Formats", "Alignments", "OrderedList", "UnorderedList",
                "Outdent", "Indent", "|",
                "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
                "SourceCode", "FullScreen", "|", "Undo", "Redo", "FileManager"
            };
            AjaxSettings = new
            {
                url = navigation.IoOperationApi,
                getImageUrl = navigation.IoGetImageApi,
                uploadUrl = navigation.IoUploadApi,
                downloadUrl = navigation.IoDownloadApi
            };
            AsyncSettings = new UploaderAsyncSettings { SaveUrl = navigation.IoSaveFileApi, 
                RemoveUrl = navigation.IoRemoveFileApi };
        }


        public async Task<IActionResult> OnPostAsync(BlogPost blog)
        {
            try
            {
                blogService.Add(blog);
                return RedirectToPage("BlogPost", new { slug = blog.Slug });
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return Page();
            }
        }
        [HttpPost]
        public void SaveImage(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var file in UploadFiles)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    if (fileName != null)
                    {
                        var filename = fileName.Trim('"');
                        filename = hostingEnv.WebRootPath + "\\Uploads" + $@"\{filename}";

                        // Create a new directory, if it does not exists
                        if (!Directory.Exists(hostingEnv.WebRootPath + "\\Uploads"))
                        {
                            Directory.CreateDirectory(hostingEnv.WebRootPath + "\\Uploads");
                        }

                        if (System.IO.File.Exists(filename)) continue;
                        using (var fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }
                    }

                    Response.StatusCode = 200;
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 204;
            }
        }
    }
}
