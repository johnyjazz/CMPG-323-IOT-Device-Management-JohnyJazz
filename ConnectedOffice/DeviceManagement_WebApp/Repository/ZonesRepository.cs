using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.iRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository : GenericRepository<Zone>, IZonesRepository
    {

        public ZonesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Zone GetMostRecentZone()
        {
            return _context.Zone.OrderByDescending(Zone => Zone.DateCreated).FirstOrDefault();
        }
    }
}
