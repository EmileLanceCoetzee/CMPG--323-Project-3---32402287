using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public async Task<Category> Details(Guid? id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);
            return(category);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<Category> AddCat(Category category)
        {
            category.CategoryId = Guid.NewGuid();
            Add(category);
            await _context.SaveChangesAsync();
            return (category);
        }

        public Category GetCatById(Guid? id)
        {
            return _context.Set<Category>().Find(id);
        }

        public Boolean CatExists(Guid? id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<Category> CatEdit(Category category)
        {            
            _context.Update(category);
            await _context.SaveChangesAsync();
            return(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<Category> DeleteCat(Guid? id)
        {
            var category = GetCatById(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return category;
        }

    }

}
