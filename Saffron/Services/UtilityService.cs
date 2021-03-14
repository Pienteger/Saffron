using SaffronEngine.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Saffron.Services
{
    public class UtilityService
    {
        public string Title { get; set; }
        public string WebsiteName { get; set; }
        public string MetaDescription { get; set; }
        public string Icon { get; set; } = "./img/writing.png";
        public int CopyEndYear { get; set; } = DateTime.Now.Year;
        public int CopyStartYear { get; set; } = DateTime.Now.Year;

        private List<string> _CustomCssList;
        /// <summary>
        /// Renders multiple css files from a given url list.
        /// Want to load a single css file? Try <c>CustomCss</c> instead.
        /// </summary>
        public List<string> CustomCssList
        {
            get
            {
                if (_CustomCssList == null)

                    _CustomCssList = new List<string>();
                return _CustomCssList;
            }
        }
        /// <summary>
        /// Renders custom css from a given url.
        /// Want to load multiple css files? Try <c>CustomCssList</c> instead.
        /// </summary>
        public string CustomCss { get; set; }
        public static string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
        public static List<Emoji> GetEmojies()
        {
            var emojieJsonPath = GetAbsolutePath("LocalData/emojies.json");
            string emojieJson = File.ReadAllText(emojieJsonPath);
            return JsonConvert.DeserializeObject<List<Emoji>>(emojieJson);
        }
    }
}
