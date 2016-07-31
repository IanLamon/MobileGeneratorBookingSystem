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
using HumanResourcesService.Models;

namespace HumanResourcesService.Controllers
{
    public class StaffMembersController : ApiController
    {
        private HumanResourcesServiceContext db = new HumanResourcesServiceContext();

        // GET: api/StaffMembers
        public IQueryable<StaffMember> GetStaffMembers()
        {
            return db.StaffMembers;
        }

        // GET: api/StaffMembers that are operators
        public IQueryable<StaffMember> GetStaffMembers(bool isOperator)
        {
            return db.StaffMembers.Where(i => i.Operator == isOperator);
        }

        // GET: api/StaffMembers/5
        [ResponseType(typeof(StaffMember))]
        public async Task<IHttpActionResult> GetStaffMember(int id)
        {
            StaffMember staffMember = await db.StaffMembers.FindAsync(id);
            if (staffMember == null)
            {
                return NotFound();
            }

            return Ok(staffMember);
        }

        // PUT: api/StaffMembers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStaffMember(int id, StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staffMember.Id)
            {
                return BadRequest();
            }

            db.Entry(staffMember).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffMemberExists(id))
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

        // POST: api/StaffMembers
        [ResponseType(typeof(StaffMember))]
        public async Task<IHttpActionResult> PostStaffMember(StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StaffMembers.Add(staffMember);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = staffMember.Id }, staffMember);
        }

        // DELETE: api/StaffMembers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> DeleteStaffMember(int id)
        {
            StaffMember staffMember = await db.StaffMembers.FindAsync(id);
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

        private bool StaffMemberExists(int id)
        {
            return db.StaffMembers.Count(e => e.Id == id) > 0;
        }
    }
}