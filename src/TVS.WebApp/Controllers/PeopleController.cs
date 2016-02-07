using System;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using System.Collections.Generic;
using TVS.WebApp.Models;

namespace TVS.WebApp.Controllers
{
    public class PeopleController : Controller
    {
        private ApplicationDbContext _context;

        public PeopleController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: People
        public IActionResult Index()
        {
            return View(_context.People.ToList());
        }

        // GET: People/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = _context.People.Single(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            var person = new Person();
            var tenantRole = _context.Roles.First(r => r.Name == "Tenant");
            var tenantroleAttributes = _context.RoleAttributes.Where(a => a.RoleId == tenantRole.Id && !string.IsNullOrEmpty(a.Attribute));

            foreach (var tenantroleAttribute in tenantroleAttributes)
            {
                var pa=new PersonAttribute();
                pa.RoleAttributeId = tenantroleAttribute.Id;
                pa.RoleAttribute = tenantroleAttribute;
                person.PersonAttributes.Add(pa);
                if (tenantroleAttribute.ValueType == "date")
                {
                    pa.DateValue=DateTime.Today;
                }
            }
            person.AddressOccupations = new List<AddressOccupation>
            {
                new AddressOccupation {Address = new Address(),OccupiedFrom = DateTime.Today, OccupiedTo = DateTime.Today}

            };
            return View(person);
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                var roleAttributes =
                    _context.RoleAttributes.Where(
                        a => person.PersonAttributes.Select(p => p.RoleAttributeId).Contains(a.Id));

                var emptyRoleAttributes = roleAttributes.Where(r => string.IsNullOrEmpty(r.Attribute)).Select(a => a.Id);

                var attributesToRemove = person.PersonAttributes.Where(a => emptyRoleAttributes.Contains(a.RoleAttributeId) || (a.StringValue==null && a.DateValue==null && a.FloatValue==null && a.IntValue==null)).ToList();

                attributesToRemove.ForEach(a=>person.PersonAttributes.Remove(a));

                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = _context.People.Single(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: People/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Person person = _context.People.Single(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            Person person = _context.People.Single(m => m.Id == id);
            _context.People.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
