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
    public class GeneratorsController : ApiController
    {
        private BookingServiceContext db = new BookingServiceContext();

        // GET: api/Generators
        public IQueryable<Generator> GetGenerators()
        {
            return db.Generators;
        }

        // GET: api/Generators/5
        [ResponseType(typeof(Generator))]
        public async Task<IHttpActionResult> GetGenerator(int id)
        {
            Generator generator = await db.Generators.FindAsync(id);
            if (generator == null)
            {
                return NotFound();
            }

            return Ok(generator);
        }

        // PUT: api/Generators/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutGenerator(int id, Generator generator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != generator.Id)
            {
                return BadRequest();
            }

            db.Entry(generator).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneratorExists(id))
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

        // POST: api/Generators
        [ResponseType(typeof(Generator))]
        public async Task<IHttpActionResult> PostGenerator(Generator generator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Generators.Add(generator);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = generator.Id }, generator);
        }

        // DELETE: api/Generators/5
        [ResponseType(typeof(Generator))]
        public async Task<IHttpActionResult> DeleteGenerator(int id)
        {
            Generator generator = await db.Generators.FindAsync(id);
            if (generator == null)
            {
                return NotFound();
            }

            db.Generators.Remove(generator);
            await db.SaveChangesAsync();

            return Ok(generator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GeneratorExists(int id)
        {
            return db.Generators.Count(e => e.Id == id) > 0;
        }
    }
}