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
using System.Web.Http.Description;
using BookingService.Models;

namespace BookingService.Controllers
{
    public class CostsController : ApiController
    {
        private BookingServiceContext db = new BookingServiceContext();

        // GET: api/Costs
        public IQueryable<Costs> GetCosts()
        {
            return db.Costs;
        }

        // GET: api/Costs/5
        [ResponseType(typeof(Costs))]
        public async Task<IHttpActionResult> GetCosts(int id)
        {
            Costs costs = await db.Costs.FindAsync(id);
            if (costs == null)
            {
                return NotFound();
            }

            return Ok(costs);
        }

        // PUT: api/Costs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCosts(int id, Costs costs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != costs.Id)
            {
                return BadRequest();
            }

            db.Entry(costs).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Costs
        [ResponseType(typeof(Costs))]
        public async Task<IHttpActionResult> PostCosts(Costs costs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Costs.Add(costs);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = costs.Id }, costs);
        }

        // DELETE: api/Costs/5
        [ResponseType(typeof(Costs))]
        public async Task<IHttpActionResult> DeleteCosts(int id)
        {
            Costs costs = await db.Costs.FindAsync(id);
            if (costs == null)
            {
                return NotFound();
            }

            db.Costs.Remove(costs);
            await db.SaveChangesAsync();

            return Ok(costs);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CostsExists(int id)
        {
            return db.Costs.Count(e => e.Id == id) > 0;
        }
    }
}