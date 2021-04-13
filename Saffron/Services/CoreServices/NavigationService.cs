using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Saffron.Services.CoreServices
{
    public class NavigationService
    {
        public string Home => "/";

        #region Account

        public string AccountManage => "/Account/Manage/Index";
        public string LogIn => "/Account/Login";
        public string LogOut => "/Account/Logout";
        public string Register => "/Account/Register";

        #endregion
        #region Blog

        public string BlogPage => "/Blog";
        public string AddNewBlog => "/Blog/AddBlog";

        #endregion

        #region API

        public string IoOperationApi => "/api/IO/FileOperations";
        public string IoGetImageApi => "/api/IO/GetImage";
        public string IoUploadApi => "/api/IO/Upload";
        public string IoDownloadApi => "/api/IO/Download";
        public string IoSaveFileApi => "/api/IO/SaveFile";
        public string IoRemoveFileApi => "/api/IO/RemoveFile";

        #endregion
    }
}
