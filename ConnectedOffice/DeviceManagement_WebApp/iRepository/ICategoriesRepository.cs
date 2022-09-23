using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.iRepository
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {
        Category GetMostRecentCategory();
    }
}
