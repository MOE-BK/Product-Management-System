
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ProductMangementSysstem.Data;
using ProductMangementSysstem.Models;

namespace ProductMangementSysstem.Controllers
{
    public class CategoryController : Controller

    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var categories = await _context.Categories
                .AsNoTracking()
                .ToListAsync();
            return View(categories);
        }
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);

            }
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Category created successfully.";
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult>Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            var category =await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return NotFound();
            }

            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id , Category category)
        
        {
            if (id != category.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Category updated successfully.";
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult>Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
                
                }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Category deleted successfully.";
            return RedirectToAction(nameof(Index));
        }


    }
}

 