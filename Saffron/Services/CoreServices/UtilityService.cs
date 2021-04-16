using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Saffron.Services.CoreServices
{
    public class UtilityService
    {
        #region Meta Tags

        public string Title { get; set; } = "Saffron";
        public string SubTitle { get; set; } = "A Cross-Platform High Performance Blog Architecture";
        public string WebsiteName { get; set; } = "Saffron Engine";
        public string Publisher { get; set; } = "Mahmudul Hasan";
        public string SiteUri { get; set; } = "https://localhost:44398";
        public string TwitterHandle { get; set; } = "@mahmudnotes";
        public string CurrentUri
        {
            get => currentUri;
            set => currentUri = SiteUri + value;
        }
        public string MetaDescription { get; set; }
        public string FeatureImage { get; set; }
        #endregion


        #region PWA

        public string Icon32 { get; set; } = "/favicon-32x32.png";
        public string Icon16 { get; set; } = "/favicon-16x16.png";
        public string Icon150 { get; set; } = "/mstile-150x150.png";
        public string Icon192 { get; set; } = "/android-chrome-192x192.png";
        public string AppleIcon { get; set; } = "/apple-touch-icon.png";
        public string SafariIcon { get; set; } = "/safari-pinned-tab.svg";
        public string SafariIconColor { get; set; } = "#5bbad5";
        public string ApplicationTitleColor { get; set; } = "#da532c";
        public string ThemeColor { get; set; } = "#ffffff";

        #endregion


        public int CopyEndYear { get; set; } = DateTime.Now.Year;
        public int CopyStartYear { get; set; } = DateTime.Now.Year;
        public DateTime ModifiedTime { get; set; }

        private List<string> customCssList;
        private string currentUri;
        private List<string> headerJsList;

        /// <summary>
        /// Renders multiple css files from a given url list.
        /// Want to load a single css file? Try <c>CustomCss</c> instead.
        /// </summary>
        public List<string> CustomCssList
        {
            get { return customCssList ??= new List<string>(); }
            set => customCssList = value;
        }
        /// <summary>
        /// Renders custom css from a given url.
        /// Want to load multiple css files? Try <c>CustomCssList</c> instead.
        /// </summary>
        public string CustomCss { get; set; }

        public string HeaderJS { get; set; }

        public List<string> HeaderJsList
        {
            get { return headerJsList ??= new List<string>(); }
            set => headerJsList = value;
        }


        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo dataRoot = new(typeof(Program).Assembly.Location);
            if (dataRoot.Directory == null) return "";
            var assemblyFolderPath = dataRoot.Directory.FullName;
            var fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
        //public static List<Emoji> GetEmojis()
        //{
        //    var emojisJsonPath = GetAbsolutePath("LocalData/emojis.json");
        //    string emojisJsonPath = File.ReadAllText(emojisJsonPath);
        //    return JsonConvert.DeserializeObject<List<Emojis>>(emojisJsonPath);
        //}
    }
}
