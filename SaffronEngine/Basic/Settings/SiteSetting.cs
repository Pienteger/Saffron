using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaffronEngine.Basic.Settings
{
    public class SiteSetting
    {
        public SiteSetting()
        {
            this.Id = 1;
        }
        public int Id { get; set; }
        public string SiteName { get; set; } = "Saffron Engine";
        public string SiteUri { get; set; } = "https://localhost:44398";
        public string Title { get; set; } = "Saffron";
        public string SubTitle { get; set; } = "A Cross-Platform High Performance Blog Architecture";
        public string Publisher { get; set; } = "Mahmudul Hasan";
        public string TwitterHandle { get; set; } = "@mahmudnotes";

        public string Icon32 { get; set; } = "/favicon-32x32.png";
        public string Icon16 { get; set; } = "/favicon-16x16.png";
        public string Icon150 { get; set; } = "/mstile-150x150.png";
        public string Icon192 { get; set; } = "/android-chrome-192x192.png";
        public string AppleIcon { get; set; } = "/apple-touch-icon.png";
        public string SafariIcon { get; set; } = "/safari-pinned-tab.svg";
        public string SafariIconColor { get; set; } = "#5bbad5";
        public string ApplicationTitleColor { get; set; } = "#da532c";
        public string ThemeColor { get; set; } = "#ffffff";

        public string GClientId { get; set; }
        public string GClientSecret { get; set; }
        public string MClientId { get; set; }
        public string MClientSecret { get; set; }
        public string GHClientId { get; set; }
        public string GHClientSecret { get; set; }
        public string FClientId { get; set; }
        public string FClientSecret { get; set; }


    }
}
