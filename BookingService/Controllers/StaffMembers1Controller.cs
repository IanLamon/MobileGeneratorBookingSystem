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
using System.Web.Http.Description;

namespace BookingService.Controllers
{
    public class StaffMembers1Controller : ODataController
    {
        //The URL of the WEB API Service
        readonly string baseUri = "http://humanresourcesservice.azurewebsites.net/odata/StaffMembers1";


        //**************************************************//
        // GET: odata/StaffMembers1: To get all staff members
        public async Task<HttpResponseMessage> GetStaffMembers1()
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
        } //ends GetStaffMembers method


        //**************************************************//
        // GET: odata/StaffMembers1(5): TO get a staff member
        [ResponseType(typeof(StaffMember))]
        public async Task<IHttpActionResult> GetStaffMember([FromODataUri]int key)
        {
            //variables
            string uri = baseUri + "(" + key + ")"; //variabe for the uri for call to external Web API
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
            if (staffMember.Id == 0)
            {
                return NotFound();
            }

            return Ok(staffMember);
        } //ends GetStaffMember method


        //**************************************************//
        // PUT: odata/StaffMembers1(5): To update an existing staff member
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<StaffMember> patch)
        {
            //check Model State is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //variabe for the uri for call to external Web API
            string uri = baseUri + "(" + key + ")";
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

            //if Staff Member does not exist return not found
            if (staffMember == null)
            {
                return NotFound();
            }

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.PutAsJsonAsync(uri, patch);
            }

            return Updated(staffMember);
        } //ends Put method


        //**************************************************//
        // POST: odata/StaffMembers1: To create a new staff member
        public async Task<IHttpActionResult> Post(StaffMember staffMember)
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
                    return Created(staffMember);
                }
            }
            return BadRequest(ModelState);
        } //ends Post method


        //**************************************************//
        //// PATCH: odata/StaffMembers1(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<StaffMember> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    StaffMember staffMember = await db.StaffMembers.FindAsync(key);
        //    if (staffMember == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(staffMember);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StaffMemberExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(staffMember);
        //}


        //**************************************************//
        // DELETE: odata/StaffMembers1(5): To delete a staff member
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            //variables
            string uri = baseUri + "(" + key + ")"; //variabe for the uri for call to external Web API
            HttpResponseMessage response = new HttpResponseMessage(); //variable for Http response

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                //check staff member exists
                response = await httpClient.GetAsync(uri);

                //if it exists
                if (response.IsSuccessStatusCode)
                {
                    //delete staff member
                    response = await httpClient.DeleteAsync(uri);
                }
                //otherwise return not found
                else
                {
                    return NotFound();
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }


        //**************************************************//
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}


        //**************************************************//
        //private bool StaffMemberExists(int key)
        //{
        //    return db.StaffMembers.Count(e => e.Id == key) > 0;
        //}
    }
}
