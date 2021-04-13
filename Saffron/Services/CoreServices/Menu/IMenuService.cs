using System;
using System.Collections.Generic;
using SaffronEngine.Basic;

namespace Saffron.Services.CoreServices.Menu
{
    public interface IMenuService
    {
        void Add(MenuItem menuItem);
        void Delete(Guid id);
        void Update(MenuItem menuItem);
        MenuItem GetMenuItem(Guid id);
        IEnumerable<MenuItem> GetMenuItems();
        IEnumerable<MenuItem> GetMenuItems(MenuType type);
    }
}
