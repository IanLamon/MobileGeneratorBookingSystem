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
    public class SubStationsController : ApiController
    {
        private BookingServiceContext db = new BookingServiceContext();

        // GET: api/SubStations
        public IQueryable<SubStation> GetSubStations()
        {
            return db.SubStations;
        }

        // GET: api/SubStations/5
        [ResponseType(typeof(SubStation))]
        public async Task<IHttpActionResult> GetSubStation(int id)
        {
            SubStation subStation = await db.SubStations.FindAsync(id);
            if (subStation == null)
            {
                return NotFound();
            }

            return Ok(subStation);
        }

        // PUT: api/SubStations/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubStation(int id, SubStation subStation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subStation.Id)
            {
                return BadRequest();
            }

            db.Entry(subStation).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubStationExists(id))
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

        // POST: api/SubStations
        [ResponseType(typeof(SubStation))]
        public async Task<IHttpActionResult> PostSubStation(SubStation subStation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubStations.Add(subStation);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = subStation.Id }, subStation);
        }

        // DELETE: api/SubStations/5
        [ResponseType(typeof(SubStation))]
        public async Task<IHttpActionResult> DeleteSubStation(int id)
        {
            SubStation subStation = await db.SubStations.FindAsync(id);
            if (subStation == null)
            {
                return NotFound();
            }

            db.SubStations.Remove(subStation);
            await db.SaveChangesAsync();

            return Ok(subStation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubStationExists(int id)
        {
            return db.SubStations.Count(e => e.Id == id) > 0;
        }
    }
}