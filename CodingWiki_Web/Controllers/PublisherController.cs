using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Publisher> pub = new();
            pub = _db.Publishers.ToList();
            return View(pub);
        }
        public IActionResult Upsert(int? id)
        {
            Publisher pub = new();
            if (id == null)
            {
                return View(pub);
            }
            else
            {
                pub = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
                return View(pub);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    await _db.Publishers.AddAsync(obj);
                }
                else
                {
                    _db.Publishers.Update(obj);
                }
                await _db.SaveChangesAsync();

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var obj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Index));
            }
            _db.Publishers.Remove(obj);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
