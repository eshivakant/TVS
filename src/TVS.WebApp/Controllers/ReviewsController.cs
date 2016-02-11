using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using TVS.WebApp.Models;

namespace TVS.WebApp.Controllers
{
    [Route("[controller]")]
    public class ReviewsController : Controller
    {
        private ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Reviews
        [HttpGet("Tenant")]
        public async Task<IActionResult> Tenant()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IEnumerable<Person>> Search([FromBody]Person person)
        {
            var queryResult = _context.People.AsQueryable();

            if (!string.IsNullOrEmpty(person.Initial))
            {
                queryResult = queryResult.Where(p => p.Initial == person.Initial);
            }
            if (!string.IsNullOrEmpty(person.FirstName))
            {
                queryResult = queryResult.Where(p => p.FirstName == person.FirstName);
            }
            if (!string.IsNullOrEmpty(person.MiddleName))
            {
                queryResult = queryResult.Where(p => p.MiddleName == person.MiddleName);
            }
            if (!string.IsNullOrEmpty(person.LastName))
            {
                queryResult = queryResult.Where(p => p.LastName == person.LastName);
            }
            if (!string.IsNullOrEmpty(person.PAN))
            {
                queryResult = queryResult.Where(p => p.PAN == person.PAN);
            }
            if (!string.IsNullOrEmpty(person.AdhaarCard))
            {
                queryResult = queryResult.Where(p => p.AdhaarCard == person.AdhaarCard);
            }
            if (!string.IsNullOrEmpty(person.PlaceOfBirth))
            {
                queryResult = queryResult.Where(p => p.PlaceOfBirth == person.PlaceOfBirth);
            }
            if (person.DateOfBirth<DateTime.Today.AddYears(-16)) //ignore this for young
            {
                queryResult = queryResult.Where(p => p.DateOfBirth>person.DateOfBirth.AddDays(-2) && p.DateOfBirth < person.DateOfBirth.AddDays(2));
            }

            if (queryResult.Count() > 100) return null; //do not return more than 100 records

            return await queryResult.ToListAsync();

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
