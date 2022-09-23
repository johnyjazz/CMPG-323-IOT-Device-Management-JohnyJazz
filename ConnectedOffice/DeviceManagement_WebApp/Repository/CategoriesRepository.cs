using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.iRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository: GenericRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(ConnectedOfficeContext context) : base(context)
        {          
        }
        public Category GetMostRecentCategory()
        {
            return _context.Category.OrderByDescending(category => category.DateCreated).FirstOrDefault();
        }

    }
}
