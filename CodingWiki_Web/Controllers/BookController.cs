using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using CodingWiki_Model.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Reflection.Metadata.BlobBuilder;

namespace CodingWiki_Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Book> obdata = _db.Books.ToList();
            return View(obdata);
        }

        public IActionResult Upsert(int? id)
        { 
            BookVM buk = new();

            buk.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            }); ;
 
            if (id == null || id == 0)
            {
                return View(buk);
            }
            else
            {
                buk.Book = _db.Books.FirstOrDefault(u => u.BookId  == id);
                 return View(buk);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BookVM obj)
        {
           
            if (ModelState.IsValid)
            {
                if (obj.Book.BookId == 0)
                {
                    await _db.Books.AddAsync(obj.Book);
                }
                else
                {
                    _db.Books.Update(obj.Book);
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
            var obj = _db.Books.FirstOrDefault(u =>u.BookId == id);
            if (obj == null)
            {
                return RedirectToAction(nameof(Index));
            }
             _db.Books.Remove(obj);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
