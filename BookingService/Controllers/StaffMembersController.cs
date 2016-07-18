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
        //The URL of the WEB API Service
        readonly string baseUri = "http://humanresourcesservice.azurewebsites.net/api/staffmembers/";

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
        } //ends GetStaffMembers method


        //**************************************************//
        // GET: api/StaffMembers: To get all staff members that are operators
        public async Task<HttpResponseMessage> GetStaffMembers(bool isOperator)
        {
            //variabes
            string uri = baseUri + "?isOperator=" + isOperator; //variabe for the uri for call to external Web API
            HttpResponseMessage response = new HttpResponseMessage(); //variable for Http response

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.GetAsync(uri);
                return response;
            }
        } //ends GetStaffMembers method


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
            if (staffMember.Id == 0)
            {
                return NotFound();
            }

            return Ok(staffMember);
        } //ends GetStaffMember method


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
        } //ends Put method


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
        } //ends Post method


        //**************************************************//
        // DELETE: api/StaffMembers/5: To delete a staff member
        [ResponseType(typeof(StaffMember))]
        public async Task<IHttpActionResult> DeleteStaffMember(int id)
        {
            //variables
            string uri = baseUri + id; //variabe for the uri for call to external Web API
            HttpResponseMessage response = new HttpResponseMessage(); //variable for Http response
            StaffMember staffMember = new StaffMember(); //variable for the staff member to return

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                //check staff member exists
                response = await httpClient.GetAsync(uri);

                //if it exists
                if (response.IsSuccessStatusCode)
                {
                    //assign result to staff member object
                    staffMember = await response.Content.ReadAsAsync<StaffMember>();
                    //delete staff member
                    response = await httpClient.DeleteAsync(uri);
                }
                //otherwise return not found
                else
                {
                    return NotFound();
                }
            }
            return Ok(staffMember);
        } //ends Delete method
    } //ends class
}