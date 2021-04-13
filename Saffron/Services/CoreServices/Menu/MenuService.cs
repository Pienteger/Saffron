using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Saffron.DataContext;
using SaffronEngine.Basic;

namespace Saffron.Services.CoreServices.Menu
{
    public class MenuService : IMenuService
    {
        private readonly SaffronContext context;

        public MenuService(SaffronContext context)
        {
            this.context = context;
        }
        public void Add(MenuItem menuItem)
        {
            context.Menus.Add(menuItem);
        }

        public void Delete(Guid id)
        {
            var temp = context.Menus.Find(id);
            if (temp == null) return;
            context.Menus.Remove(temp);
            context.SaveChanges();
        }

        public MenuItem GetMenuItem(Guid id)
        {
            return context.Menus.Find(id);
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            return context.Menus;
        }

        public IEnumerable<MenuItem> GetMenuItems(MenuType type)
        {
            return context.Menus.Where(x => x.MenuType == type);
        }

        public void Update(MenuItem menuItem)
        {
            var temp = context.Menus.Attach(menuItem);
            temp.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}