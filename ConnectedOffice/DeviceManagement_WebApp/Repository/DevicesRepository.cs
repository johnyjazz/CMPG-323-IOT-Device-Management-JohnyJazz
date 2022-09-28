using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.iRepository;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository : GenericRepository<Device>, IDevicesRepository
    {

        public DevicesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public Device GetMostRecentDevice()
        {
            return _context.Device.OrderByDescending(device => device.DateCreated).FirstOrDefault();
        }

    }
}
