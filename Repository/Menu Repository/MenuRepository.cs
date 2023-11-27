using BooksStoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreWebAPI.Repository.Menu_Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BookDbContext context;

        public MenuRepository(BookDbContext context)
        {
            this.context = context;
        }
        public async Task<Menu> AddMenu(Menu menu)
        {
            try
            {
                if(menu == null)
                {
                    return null;
                }
               await context.Menus.AddAsync(menu);
               await context.SaveChangesAsync();
                return menu;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Menu?> DeleteMenuById(int id)
        {
            try
            {
                var menu =await context.Menus.FirstOrDefaultAsync(a => a.MenuId == id);
                if (menu == null)
                {
                    return null;
                }
                context.Menus.Remove(menu);
               await context.SaveChangesAsync();
                return menu;

            }catch(Exception ex)
            {
                return null;
            }
           
        }

        public Task<List<Menu>> GetAllMenu()
        {
            return context.Menus.ToListAsync();
        }

        public async Task<Menu?> GetMenuById(int id)
        {
            try
            {
                var menu = await context.Menus.FirstOrDefaultAsync(a => a.MenuId == id);
                if (menu == null)
                {
                    return null;
                }
                return menu;

            }
            catch(Exception ex)
            {
                return null;
            }
        }


        public async Task<Menu?> UpdateMenuById(int menuId, Menu menu)
        {
            try { 
            var resMenu = await context.Menus.FirstOrDefaultAsync(a => a.MenuId == menuId);
            if (resMenu == null)
            {
                return null;
            }
            resMenu.MenuText = menu.MenuText;
            resMenu.Url = menu.Url;
            resMenu.RoleRights = menu.RoleRights;

            await context.SaveChangesAsync();
            return resMenu;

        }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
