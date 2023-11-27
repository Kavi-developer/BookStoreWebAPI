using BooksStoreWebAPI.Models;

namespace BooksStoreWebAPI.Repository.Menu_Repository
{
    public interface IMenuRepository
    {
       Task<List<Menu>> GetAllMenu();
        Task<Menu?> GetMenuById(int id);
        Task<Menu> AddMenu(Menu menu);  
        Task<Menu?> UpdateMenuById(int menuId,Menu menu);
        Task<Menu?> DeleteMenuById(int id);

        
    }
}
