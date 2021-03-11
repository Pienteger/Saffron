using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaffronEngine.Basic;
namespace Saffron.Services
{
    public interface IMenuService
    {
        void Add(MenuItem menuItem);
        void Delete(Guid Id);
        void Update(MenuItem menuItem);
        MenuItem GetMenuItem(Guid Id);
        IReadOnlyList<MenuItem> GetMenuItems();
        IReadOnlyList<MenuItem> GetMenuItems(MenuType type);
    }
    public class MenuService : IMenuService
    {
        public void Add(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public MenuItem GetMenuItem(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<MenuItem> GetMenuItems()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<MenuItem> GetMenuItems(MenuType type)
        {
            throw new NotImplementedException();
        }

        public void Update(MenuItem menuItem)
        {
            throw new NotImplementedException();
        }
    }
    public enum MenuType
    {

    }
}
