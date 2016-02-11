using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using TVS.WebApp.Models;

namespace TVS.WebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Reviews
        public async Task<IActionResult> Tenant()
        {
            return View();
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = await _context.People.SingleAsync(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = await _context.People.SingleAsync(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Reviews/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = await _context.People.SingleAsync(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            Person person = await _context.People.SingleAsync(m => m.Id == id);
            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
