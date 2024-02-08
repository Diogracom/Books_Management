using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingWiki_Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Author> obdata = _db.Publisher.ToList();
            return View(obdata);
        }

        public IActionResult Upsert(int? id)
        {
            Author author = new();
            if (id == null)
            {
                return View(author);
            }
            else
            {
                author = _db.Publisher.FirstOrDefault(u => u.Author_Id == id);
                 return View(author);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Author obj)
        {
           
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    await _db.Publisher.AddAsync(obj);
                }
                else
                {
                    _db.Publisher.Update(obj);
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
            var obj = _db.Publisher.FirstOrDefault(u =>u.Author_Id == id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Index));
            }
             _db.Publisher.Remove(obj);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
