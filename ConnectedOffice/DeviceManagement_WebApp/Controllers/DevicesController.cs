using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;
using DeviceManagement_WebApp.iRepository;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDevicesRepository _DevicesRepository;
               

        public DevicesController(IDevicesRepository DevicesRepository)
        {
            _DevicesRepository = DevicesRepository;

        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            return View(_DevicesRepository.GetAll());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zone = _DevicesRepository.GetById(id);
            if (zone == null)
            {
                return NotFound();
            }

            return View(zone);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Devices/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,DeviceDescription,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            //ViewBag.CategoryId = device.CategoryId.Tolist();
            
            //var items = _categoriesRepository.GetAll().ToList() ;
            //ViewBag.data = items;
            _DevicesRepository.Add(device);
            _DevicesRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = _DevicesRepository.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        //// POST: Devices/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,DeviceDescription,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }

            try
            {
                _DevicesRepository.Update(device);
                _DevicesRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return RedirectToAction(nameof(Index));

        }

        //// GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _DevicesRepository.GetById(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Device device)
        {

            _DevicesRepository.Remove(device);
            _DevicesRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            return ModelState.IsValid;
        }

    }
}