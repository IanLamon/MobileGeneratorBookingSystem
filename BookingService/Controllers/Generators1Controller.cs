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
    public class Generators1Controller : ODataController
    {
        private BookingServiceContext db = new BookingServiceContext();

        // GET: odata/Generators1
        [EnableQuery]
        public IQueryable<Generator> GetGenerators1()
        {
            return db.Generators;
        }

        // GET: odata/Generators1(5)
        [EnableQuery]
        public SingleResult<Generator> GetGenerator([FromODataUri] int key)
        {
            return SingleResult.Create(db.Generators.Where(generator => generator.Id == key));
        }

        // PUT: odata/Generators1(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<Generator> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Generator generator = await db.Generators.FindAsync(key);
            if (generator == null)
            {
                return NotFound();
            }

            patch.Put(generator);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneratorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(generator);
        }

        // POST: odata/Generators1
        public async Task<IHttpActionResult> Post(Generator generator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Generators.Add(generator);
            await db.SaveChangesAsync();

            return Created(generator);
        }

        // PATCH: odata/Generators1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Generator> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Generator generator = await db.Generators.FindAsync(key);
            if (generator == null)
            {
                return NotFound();
            }

            patch.Patch(generator);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneratorExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(generator);
        }

        // DELETE: odata/Generators1(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Generator generator = await db.Generators.FindAsync(key);
            if (generator == null)
            {
                return NotFound();
            }

            db.Generators.Remove(generator);
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

        private bool GeneratorExists(int key)
        {
            return db.Generators.Count(e => e.Id == key) > 0;
        }
    }
}
