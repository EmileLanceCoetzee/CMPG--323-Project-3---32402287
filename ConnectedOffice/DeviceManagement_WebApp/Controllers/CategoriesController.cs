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

namespace DeviceManagement_WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        //private readonly ConnectedOfficeContext _context;
        private readonly ICategoryRepository _CategoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }

        // GET: Categories

        public async Task<IActionResult> Index()
        {
            return View(_CategoryRepository.GetAll());
        }
        
        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            return View(await _CategoryRepository.Details(id));
        }

        // GET: Categories/Create

        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            await _CategoryRepository.AddCat(category);
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = _CategoryRepository.GetCatById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }
            try
            {
                await _CategoryRepository.CatEdit(category);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_CategoryRepository.CatExists(id))
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
        
        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category category = _CategoryRepository.GetCatById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            await _CategoryRepository.DeleteCat(id);
            return RedirectToAction(nameof(Index));
        }
        
        private bool CategoryExists(Guid id)
        {
            return _CategoryRepository.CatExists(id);
        }
    }
}
