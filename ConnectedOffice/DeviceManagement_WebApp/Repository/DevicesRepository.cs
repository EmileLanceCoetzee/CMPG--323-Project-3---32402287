using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.Repository
{
    public class DevicesRepository : GenericRepository<Device>, IDevicesRepository
    {
        public DevicesRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public IEnumerable<Device> Index()
        {
            return _context.Device.Include(d => d.Category).Include(d => d.Zone).ToList();
        }

        public async Task<Device> Details(Guid? id)
        {

            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);

            return device;
        }

        public DbSet<Category> CatList()
        {
            return _context.Category;
        }

        public DbSet<Zone> ZoneList()
        {
            return _context.Zone;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Device> AddDevice(Device device)
        {
            device.DeviceId = Guid.NewGuid();
            Add(device);
            await _context.SaveChangesAsync();
            return (device);
        }

        public Device GetDeviceById(Guid? id)
        {
            return _context.Set<Device>().Find(id);
        }

        public Boolean DeviceExists(Guid? id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<Device> DeviceEdit(Device device)
        {
            _context.Update(device);
            await _context.SaveChangesAsync();
            return (device);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<Device> DeleteDevice(Guid? id)
        {
            var device = GetDeviceById(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return device;
        }

    }
}
