using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using System.Linq.Expressions;

namespace DeviceManagement_WebApp.Repository
{
    public interface IZonesRepository : IGenericRepository<Zone>
    {
        Task<Zone> Details(Guid? id);

        Task<Zone> AddZone(Zone zone);

        Zone GetZoneById(Guid? id);

        Boolean ZoneExists(Guid? id);

        Task<Zone> ZoneEdit(Zone zone);

        Task<Zone> DeleteZone(Guid? id);


    }
}
