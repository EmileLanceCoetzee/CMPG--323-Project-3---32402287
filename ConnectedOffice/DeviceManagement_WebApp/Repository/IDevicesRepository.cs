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
    public interface IDevicesRepository : IGenericRepository<Device>
    {

        IEnumerable<Device> Index();

        Task<Device> Details(Guid? id);

        DbSet<Category> CatList();

        DbSet<Zone> ZoneList();

        Task<Device> AddDevice(Device device);

        Device GetDeviceById(Guid? id);

        Boolean DeviceExists(Guid? id);

        Task<Device> DeviceEdit(Device device);

        Task<Device> DeleteDevice(Guid? id);


    }
}
