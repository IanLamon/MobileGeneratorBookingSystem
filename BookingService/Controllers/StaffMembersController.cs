using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookingService.Models;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace BookingService.Controllers
{
    public class StaffMembersController : ApiController
    {
        /*
        private BookingServiceContext db = new BookingServiceContext();
        
        // GET: api/StaffMembers
        public IQueryable<StaffMember> GetStaffMembers()
        {
            return db.StaffMembers;
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
        [ResponseType(typeof(StaffMember))]
        public async Task<IHttpActionResult> DeleteStaffMember(int id)
        {
            StaffMember staffMember = await db.StaffMembers.FindAsync(id);
            if (staffMember == null)
            {
                return NotFound();
            }

            db.StaffMembers.Remove(staffMember);
            await db.SaveChangesAsync();

            return Ok(staffMember);
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
         */

        //new code to try and consume external Web API
        //The URL of the WEB API Service
        readonly string baseUri = "http://humanresourcesservice.azurewebsites.net/api/StaffMembers/";


        //**************************************************//
        // GET: api/StaffMembers: To get all staff members
        public async Task<HttpResponseMessage> GetStaffMembers()
        {
            //variabes
            string uri = baseUri; //variabe for the uri for call to external Web API
            HttpResponseMessage response = new HttpResponseMessage(); //variable for Http response

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.GetAsync(uri);
                return response;
            }

        } //ends GetStaffMembers


        //**************************************************//
        // GET: api/StaffMembers/5: To get an individual staff member
        [ResponseType(typeof(StaffMember))]
        public async Task<IHttpActionResult> GetStaffMember(int id)
        {
            //variables
            string uri = baseUri + id; //variabe for the uri for call to external Web API
            HttpResponseMessage response = new HttpResponseMessage(); //variable for Http response
            StaffMember staffMember = new StaffMember(); //variable for the staff member to return

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.GetAsync(uri);
            }

            //assign returning data to object
            if (response.IsSuccessStatusCode)
            {
                staffMember = await response.Content.ReadAsAsync<StaffMember>();
            }

            //if staff member does not exist return not found
            if (staffMember == null)
            {
                return NotFound();
            }

            return Ok(staffMember);
        } //ends GetStaffMember


        //**************************************************//
        // PUT: api/StaffMembers/5: To update an existing staff member
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStaffMember(int id, StaffMember staffMember)
        {
            //check Model State is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check ids match
            if (id != staffMember.Id)
            {
                return BadRequest();
            }

            //variabe for the uri for call to external Web API
            string uri = baseUri + id;
            
            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(uri, staffMember);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        //**************************************************//
        // POST: api/StaffMembers: To create a new staff member
        [ResponseType(typeof(StaffMember))]
        public async Task<IHttpActionResult> PostStaffMember(StaffMember staffMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //variabe for the uri for call to external Web API
            string uri = baseUri;
            StaffMember newStaffMember = new StaffMember();

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri, staffMember);

                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    newStaffMember = await response.Content.ReadAsAsync<StaffMember>();

                    //return new staff member
                    return CreatedAtRoute("DefaultApi", new { id = newStaffMember.Id }, newStaffMember);
                }
            }

            return BadRequest(ModelState);
        }

        //ends new code
    }
}