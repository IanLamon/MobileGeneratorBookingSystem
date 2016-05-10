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
using SubStationService.Models;

namespace SubStationService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using SubStationService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<SubStation>("SubStations1");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class SubStations1Controller : ODataController
    {
        private SubStationServiceContext db = new SubStationServiceContext();

        // GET: odata/SubStations1
        [EnableQuery]
        public IQueryable<SubStation> GetSubStations1()
        {
            return db.SubStations;
        }

        // GET: odata/SubStations1(5)
        [EnableQuery]
        public SingleResult<SubStation> GetSubStation([FromODataUri] int key)
        {
            return SingleResult.Create(db.SubStations.Where(subStation => subStation.Id == key));
        }

        // PUT: odata/SubStations1(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<SubStation> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubStation subStation = await db.SubStations.FindAsync(key);
            if (subStation == null)
            {
                return NotFound();
            }

            patch.Put(subStation);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubStationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(subStation);
        }

        // POST: odata/SubStations1
        public async Task<IHttpActionResult> Post(SubStation subStation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubStations.Add(subStation);
            await db.SaveChangesAsync();

            return Created(subStation);
        }

        // PATCH: odata/SubStations1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<SubStation> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SubStation subStation = await db.SubStations.FindAsync(key);
            if (subStation == null)
            {
                return NotFound();
            }

            patch.Patch(subStation);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubStationExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(subStation);
        }

        // DELETE: odata/SubStations1(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            SubStation subStation = await db.SubStations.FindAsync(key);
            if (subStation == null)
            {
                return NotFound();
            }

            db.SubStations.Remove(subStation);
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

        private bool SubStationExists(int key)
        {
            return db.SubStations.Count(e => e.Id == key) > 0;
        }
    }
}
