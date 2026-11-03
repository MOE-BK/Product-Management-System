
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductMangementSysstem.Data;
using ProductMangementSysstem.Models;
using ProductMangementSysstem.ViewModel;

namespace ProductMangementSysstem.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // Index + Search + Filter + Sorting + Pagination
        public async Task<IActionResult> Index(
            string? search,
            int? categoryId,
            string? sortOrder,
            int page = 1)
        {
            const int pageSize = 10;

            if (page < 1)
                page = 1;

            var query = _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .AsQueryable();

            // Search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(p =>
                    p.Name.Contains(search));
            }

            // Category Filter
            if (categoryId.HasValue)
            {
                query = query.Where(p =>
                    p.CategoryId == categoryId.Value);
            }

            // Sorting
            query = sortOrder switch
            {
                "price_asc" => query.OrderBy(p => p.Price),
                "price_desc" => query.OrderByDescending(p => p.Price),
                "name_desc" => query.OrderByDescending(p => p.Name),
                _ => query.OrderBy(p => p.Name)
            };

            // Total Items
            var totalItems = await query.CountAsync();

            // Pagination
            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Data for View
            ViewBag.CurrentPage = page;

            ViewBag.TotalPages =
                (int)Math.Ceiling(
                    totalItems / (double)pageSize);

            ViewBag.Search = search;
            ViewBag.CategoryId = categoryId;
            ViewBag.SortOrder = sortOrder;
            ViewBag.Categories = await GetCategories();

            return View(products);
        }

        // Create - GET
        public async Task<IActionResult> Create()
        {
            var model = new ProductViewModel
            {
                Categories = await GetCategories()
            };

            return View(model);
        }

        // Get Categories
        private async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            return await _context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToListAsync();
        }

        // Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId
            };

            if (model.Cover != null)
            {
                product.ImageUrl = await SaveImage(model.Cover);
            }

            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Product created successfully.";

            return RedirectToAction(nameof(Index));
        }

        // Save Image
        private async Task<string> SaveImage(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);

            var fileName = $"{Guid.NewGuid()}{extension}";

            var folder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "images");

            Directory.CreateDirectory(folder);

            var filePath = Path.Combine(folder, fileName);

            using var stream = new FileStream(
                filePath,
                FileMode.Create);

            await image.CopyToAsync(stream);

            return $"/images/{fileName}";
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // Edit - GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            var model = new ProductViewModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                Categories = await GetCategories()
            };

            ViewBag.ProductId = product.Id;
            ViewBag.CurrentImage = product.ImageUrl;

            return View(model);
        }

        // Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                var currentProduct = await _context.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (currentProduct == null)
                    return NotFound();

                ViewBag.ProductId = currentProduct.Id;
                ViewBag.CurrentImage = currentProduct.ImageUrl;

                return View(model);
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Stock = model.Stock;
            product.CategoryId = model.CategoryId;

            if (model.Cover != null)
            {
                product.ImageUrl = await SaveImage(model.Cover);
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Product updated successfully.";

            return RedirectToAction(nameof(Index));
        }

        // Delete - GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return NotFound();

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Product deleted successfully.";

            return RedirectToAction(nameof(Index));
        }
    }
}
