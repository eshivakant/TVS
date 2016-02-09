using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using TVS.WebApp.Models;

namespace TVS.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Landlord")]
    [Authorize(Roles = "Landlord,Tenant")]
    public class LandlordController : Controller
    {
        private ApplicationDbContext _context;

        public LandlordController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public Person GetLandlord([FromQuery]string role)
        {
            //var role = "Tenant";
            var person = new Person(){DateOfBirth = DateTime.Today};

            if (role.ToLower() == "landlord")
            {
                var landlordRole = _context.Roles.First(r => r.Name == role);
                var roleAttributes =
                    _context.RoleAttributes.Where(a => a.RoleId == landlordRole.Id && !string.IsNullOrEmpty(a.Attribute));

                foreach (var tenantroleAttribute in roleAttributes)
                {
                    var pa = new PersonAttribute();
                    pa.RoleAttributeId = tenantroleAttribute.Id;
                    pa.RoleAttribute = tenantroleAttribute;
                    if (tenantroleAttribute.ValueType == "date")
                    {
                        pa.DateValue = DateTime.Today;
                    }

                    person.PersonAttributes.Add(pa);
                }

                person.AddressOwnerships = new List<AddressOwnership>
                    {
                        new AddressOwnership {Address = new Address {AddressLine1 = "Line 1", City = "City", PostCode = "Pin"}, OwnedFrom = DateTime.Today, OwnedTo = DateTime.Today}
                    };

            }

            return person;
        }

        // POST: api/Api
        [HttpPost]
        public async Task<bool> PostLandlord([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }

            try
            {
            if (ModelState.IsValid)
            {
                //insert new addresses
                foreach (var addressOccupation in person.AddressOwnerships)
                {
                    if (addressOccupation.Address.Id == 0)
                    {
                        _context.Addresses.Add(addressOccupation.Address);
                    }
                    _context.SaveChanges();
                    addressOccupation.AddressId = addressOccupation.Address.Id;
                }


                var roleAttributes =
                    _context.RoleAttributes.Where(
                        a => person.PersonAttributes.Select(p => p.RoleAttributeId).Contains(a.Id));

                var emptyRoleAttributes = roleAttributes.Where(r => string.IsNullOrEmpty(r.Attribute)).Select(a => a.Id);

                var attributesToRemove = person.PersonAttributes.Where(a => emptyRoleAttributes.Contains(a.RoleAttributeId) || (a.StringValue == null && a.DateValue == null && a.FloatValue == null && a.IntValue == null)).ToList();

                attributesToRemove.ForEach(a => person.PersonAttributes.Remove(a));



                _context.People.Add(person);
                await _context.SaveChangesAsync();
            }
            }
            catch (Exception)
            {
                return false;
            }
           

            return true;
        }



        [HttpGet("{id}")]
        public IActionResult GetLandlord([FromRoute] long id)
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
        public IActionResult PutLandlord(long id, [FromBody] Person person)
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

       

        // DELETE: api/Api/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLandlord(long id)
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