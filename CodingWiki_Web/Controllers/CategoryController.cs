using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db) 
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> obdata = _db.Categories.ToList();
            return View(obdata);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new();
            if(id == null || id == 0) 
            {
                //Create Category
                return View(obj);
            }

            //edit Category
            obj =  _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj != null)
            {
                return View(obj);

            }
           return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        { 
            if(ModelState.IsValid)
            {
                //add Category
                if(obj.CategoryId == 0)
                {
                    await _db.Categories.AddAsync(obj);
                }
                else
                {
                    //Update Category
                    _db.Categories.Update(obj);
                }

                await  _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                 
            }
            return View(obj);
        }

        public async Task<IActionResult> Delete(int id) 
        {
            Category obj = new();
            obj = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
           await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
