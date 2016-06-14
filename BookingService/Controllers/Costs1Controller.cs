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
    public class Costs1Controller : ODataController
    {
        private BookingServiceContext db = new BookingServiceContext();

        // GET: odata/Costs1
        [EnableQuery]
        public IQueryable<Costs> GetCosts1()
        {
            return db.Costs;
        }

        // GET: odata/Costs1(5)
        [EnableQuery]
        public SingleResult<Costs> GetCosts([FromODataUri] int key)
        {
            return SingleResult.Create(db.Costs.Where(costs => costs.Id == key));
        }

        // PUT: odata/Costs1(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Costs> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Costs costs = await db.Costs.FindAsync(key);
            if (costs == null)
            {
                return NotFound();
            }

            patch.Put(costs);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(costs);
        }

        // POST: odata/Costs1
        public async Task<IHttpActionResult> Post(Costs costs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Costs.Add(costs);
            await db.SaveChangesAsync();

            return Created(costs);
        }

        // PATCH: odata/Costs1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Costs> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Costs costs = await db.Costs.FindAsync(key);
            if (costs == null)
            {
                return NotFound();
            }

            patch.Patch(costs);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostsExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(costs);
        }

        // DELETE: odata/Costs1(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Costs costs = await db.Costs.FindAsync(key);
            if (costs == null)
            {
                return NotFound();
            }

            db.Costs.Remove(costs);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CostsExists(int key)
        {
            return db.Costs.Count(e => e.Id == key) > 0;
        }
    }
}
