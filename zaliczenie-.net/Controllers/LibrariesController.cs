using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using zaliczenie_.net.Models;


namespace zaliczenie_.net.Controllers
{
    public class LibrariesController : Controller
    {
        private readonly LibraryContext _context;

        public LibrariesController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Libraries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        // GET: Libraries/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Books
                .FirstOrDefaultAsync(m => m.idBook == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // GET: Libraries/Create
        [Authorize(Roles = "Librarian")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Libraries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idBook,Tittle,Author,Section,Status")] Library library)
        {
            if (ModelState.IsValid)
            {
                _context.Add(library);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(library);
        }

        [Authorize(Roles = "Librarian")]

        // GET: Libraries/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var library = await _context.Books.FirstOrDefaultAsync(book => book.idBook == id);
            if (library == null)
            {
                return NotFound();
            }
            return View(library);
        }

        // POST: Libraries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Librarian")]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Tittle,Author,Section,Status")] Library library)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(book => book.idBook == id);
            if (ModelState.IsValid)
            {
                try
                {
                    existingBook.Tittle = library.Tittle;
                    existingBook.Author = library.Author;
                    existingBook.Section = library.Section;
                    existingBook.Status = library.Status;

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryExists(library.idBook))
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
            return View(library);
        }

        // GET: Libraries/Delete/5
        [Authorize(Roles = "Librarian")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var library = await _context.Books.FirstOrDefaultAsync(book => book.idBook == id);
            if (library == null)
            {
                return NotFound();
            }

            return View(library);
        }

        // POST: Libraries/Delete/5
        [Authorize(Roles = "Librarian")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var library = await _context.Books.FirstOrDefaultAsync(book => book.idBook == id);
            _context.Books.Remove(library);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryExists(int id)
        {
            return _context.Books.Any(e => e.idBook == id);
        }

        public async Task<IActionResult> Search(string searchString)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var books = from m in _context.Books
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Tittle!.Contains(searchString));
            }

            return View(await books.ToListAsync());
        }

    }
}