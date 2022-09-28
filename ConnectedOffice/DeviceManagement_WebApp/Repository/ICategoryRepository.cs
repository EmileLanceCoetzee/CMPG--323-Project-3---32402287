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
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> Details(Guid? id);

        Task<Category> AddCat(Category category);

        Category GetCatById(Guid? id);

        Boolean CatExists(Guid? id);

        Task<Category> CatEdit(Category category);

        Task<Category> DeleteCat(Guid? id);


    }

}
