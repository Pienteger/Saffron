using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Saffron.DataContex;
using SaffronEngine.Basic;

namespace Saffron.Services
{
    public interface IMenuService
    {
        void Add(MenuItem menuItem);
        void Delete(Guid Id);
        void Update(MenuItem menuItem);
        MenuItem GetMenuItem(Guid Id);
        IEnumerable<MenuItem> GetMenuItems();
        IEnumerable<MenuItem> GetMenuItems(MenuType type);
    }
    public class MenuService : IMenuService
    {
        private readonly SaffronDbContex contex;

        public MenuService(SaffronDbContex contex)
        {
            this.contex = contex;
        }
        public void Add(MenuItem menuItem)
        {
            contex.Menus.Add(menuItem);
        }

        public void Delete(Guid Id)
        {
            var temp = contex.Menus.Find(Id);
            if (temp != null)
            {
                contex.Menus.Remove(temp);
                contex.SaveChanges();
            }
        }

        public MenuItem GetMenuItem(Guid Id)
        {
            return contex.Menus.Find(Id);
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            return contex.Menus;
        }

        public IEnumerable<MenuItem> GetMenuItems(MenuType type)
        {
            return contex.Menus.Where(x => x.MenuType == type);
        }

        public void Update(MenuItem menuItem)
        {
            var temp = contex.Menus.Attach(menuItem);
            temp.State = EntityState.Modified;
            contex.SaveChanges();
        }
    }
}
