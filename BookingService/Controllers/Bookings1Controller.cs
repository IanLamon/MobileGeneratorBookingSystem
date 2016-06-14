using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using BookingService.Models;

namespace BookingService.Controllers
{
    
    public class Bookings1Controller : ODataController
    {
        private BookingServiceContext db = new BookingServiceContext();

        // GET: odata/Bookings1
        [EnableQuery]
        public IQueryable<Booking> GetBookings1()
        {
            return db.Bookings;
        }

        // GET: odata/Bookings1(5)
        [EnableQuery]
        public SingleResult<Booking> GetBooking([FromODataUri] int key)
        {
            return SingleResult.Create(db.Bookings.Where(booking => booking.Id == key));
        }

        // PUT: odata/Bookings1(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Booking> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Booking booking = await db.Bookings.FindAsync(key);
            if (booking == null)
            {
                return NotFound();
            }

            patch.Put(booking);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(booking);
        }

        // POST: odata/Bookings1
        public async Task<IHttpActionResult> Post(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();

            return Created(booking);
        }

        // PATCH: odata/Bookings1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Booking> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Booking booking = await db.Bookings.FindAsync(key);
            if (booking == null)
            {
                return NotFound();
            }

            patch.Patch(booking);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(booking);
        }

        // DELETE: odata/Bookings1(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Booking booking = await db.Bookings.FindAsync(key);
            if (booking == null)
            {
                return NotFound();
            }

            db.Bookings.Remove(booking);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Bookings1(5)/Approver
        [EnableQuery]
        public SingleResult<StaffMember> GetApprover([FromODataUri] int key)
        {
            return SingleResult.Create(db.Bookings.Where(m => m.Id == key).Select(m => m.Approver));
        }

        // GET: odata/Bookings1(5)/Generator
        [EnableQuery]
        public SingleResult<Generator> GetGenerator([FromODataUri] int key)
        {
            return SingleResult.Create(db.Bookings.Where(m => m.Id == key).Select(m => m.Generator));
        }

        // GET: odata/Bookings1(5)/Operator1
        [EnableQuery]
        public SingleResult<StaffMember> GetOperator1([FromODataUri] int key)
        {
            return SingleResult.Create(db.Bookings.Where(m => m.Id == key).Select(m => m.Operator1));
        }

        // GET: odata/Bookings1(5)/Operator2
        [EnableQuery]
        public SingleResult<StaffMember> GetOperator2([FromODataUri] int key)
        {
            return SingleResult.Create(db.Bookings.Where(m => m.Id == key).Select(m => m.Operator2));
        }

        // GET: odata/Bookings1(5)/SubStation
        [EnableQuery]
        public SingleResult<SubStation> GetSubStation([FromODataUri] int key)
        {
            return SingleResult.Create(db.Bookings.Where(m => m.Id == key).Select(m => m.SubStation));
        }

        // GET: odata/Bookings1(5)/TrafficManager
        [EnableQuery]
        public SingleResult<StaffMember> GetTrafficManager([FromODataUri] int key)
        {
            return SingleResult.Create(db.Bookings.Where(m => m.Id == key).Select(m => m.TrafficManager));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(int key)
        {
            return db.Bookings.Count(e => e.Id == key) > 0;
        }
    }
}
