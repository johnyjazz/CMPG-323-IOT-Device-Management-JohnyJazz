using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository
    {
        private readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();

        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }
    }
}
