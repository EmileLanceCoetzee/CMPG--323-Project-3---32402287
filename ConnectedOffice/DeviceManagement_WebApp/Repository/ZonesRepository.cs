using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public class ZonesRepository : GenericRepository<Zone>, IZonesRepository
    {
        public ZonesRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public async Task<Zone> Details(Guid? id)
        {
            var zone = await _context.Zone.FirstOrDefaultAsync(m => m.ZoneId == id);
            return (zone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Zone> AddZone(Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            Add(zone);
            await _context.SaveChangesAsync();
            return (zone);
        }

        public Zone GetZoneById(Guid? id)
        {
            return _context.Set<Zone>().Find(id);
        }

        public Boolean ZoneExists(Guid? id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<Zone> ZoneEdit(Zone zone)
        {
            _context.Update(zone);
            await _context.SaveChangesAsync();
            return (zone);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<Zone> DeleteZone(Guid? id)
        {
            var zone = GetZoneById(id);
            _context.Zone.Remove(zone);
            await _context.SaveChangesAsync();
            return zone;
        }

    }
}
