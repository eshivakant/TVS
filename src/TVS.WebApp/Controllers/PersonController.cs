using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using TVS.WebApp.Models;

namespace TVS.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Person")]
    public class PersonController : Controller
    {
        private ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Person GetPerson([FromQuery]string role)
        {
            //var role = "Tenant";
            var person = new Person(){FirstName = "Shivakant"};

            if (role.ToLower() == "tenant")
            {
                var tenantRole = _context.Roles.First(r => r.Name == role);
                var tenantroleAttributes =
                    _context.RoleAttributes.Where(a => a.RoleId == tenantRole.Id && !string.IsNullOrEmpty(a.Attribute));

                foreach (var tenantroleAttribute in tenantroleAttributes)
                {
                    var pa = new PersonAttribute();
                    pa.RoleAttributeId = tenantroleAttribute.Id;
                    pa.RoleAttribute = tenantroleAttribute;
                    person.PersonAttributes.Add(pa);
                    person.AddressOccupations = new List<AddressOccupation>
                    {
                        new AddressOccupation {Address = new Address {City = "Lucknow"}}
                    };
                }

            }

            return person;
        }

        //// GET: api/Api
        //[HttpGet]
        //public IEnumerable<Person> GetPeople()
        //{
        //    return _context.People;
        //}

        // GET: api/Api/5
        [HttpGet("{id}", Name = "GetPerson")]
        public IActionResult GetPerson([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Person person = _context.People.Single(m => m.Id == id);

            if (person == null)
            {
                return HttpNotFound();
            }

            return Ok(person);
        }

        // PUT: api/Api/5
        [HttpPut("{id}")]
        public IActionResult PutPerson(long id, [FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            if (id != person.Id)
            {
                return HttpBadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return HttpNotFound();
                }
                else
                {
                    throw;
                }
            }

            return new HttpStatusCodeResult(StatusCodes.Status204NoContent);
        }

        // POST: api/Api
        [HttpPost]
        public IActionResult PostPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            _context.People.Add(person);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PersonExists(person.Id))
                {
                    return new HttpStatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/Api/5
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            if (!ModelState.IsValid)
            {
                return HttpBadRequest(ModelState);
            }

            Person person = _context.People.Single(m => m.Id == id);
            if (person == null)
            {
                return HttpNotFound();
            }

            _context.People.Remove(person);
            _context.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonExists(long id)
        {
            return _context.People.Count(e => e.Id == id) > 0;
        }
    }
}