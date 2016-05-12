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
using HumanResourcesService.Models;

namespace HumanResourcesService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using HumanResourcesService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<StaffMember>("StaffMembers1");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class StaffMembers1Controller : ODataController
    {
        private HumanResourcesServiceContext db = new HumanResourcesServiceContext();

        // GET: odata/StaffMembers1
        [EnableQuery]
        public IQueryable<StaffMember> GetStaffMembers1()
        {
            return db.StaffMembers;
        }

        // GET: odata/StaffMembers1(5)
        [EnableQuery]
        public SingleResult<StaffMember> GetStaffMember([FromODataUri] int key)
        {
            return SingleResult.Create(db.StaffMembers.Where(staffMember => staffMember.Id == key));
        }

        // PUT: odata/StaffMembers1(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<StaffMember> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StaffMember staffMember = await db.StaffMembers.FindAsync(key);
            if (staffMember == null)
            {
                return NotFound();
            }

            patch.Put(staffMember);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffMemberExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(staffMember);
        }

        // POST: odata/StaffMembers1
        public async Task<IHttpActionResult> Post(StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StaffMembers.Add(staffMember);
            await db.SaveChangesAsync();

            return Created(staffMember);
        }

        // PATCH: odata/StaffMembers1(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<StaffMember> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StaffMember staffMember = await db.StaffMembers.FindAsync(key);
            if (staffMember == null)
            {
                return NotFound();
            }

            patch.Patch(staffMember);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffMemberExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(staffMember);
        }

        // DELETE: odata/StaffMembers1(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            StaffMember staffMember = await db.StaffMembers.FindAsync(key);
            if (staffMember == null)
            {
                return NotFound();
            }

            db.StaffMembers.Remove(staffMember);
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

        private bool StaffMemberExists(int key)
        {
            return db.StaffMembers.Count(e => e.Id == key) > 0;
        }
    }
}
