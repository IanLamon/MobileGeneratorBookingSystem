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
        //The URL of the WEB API Service
        readonly string baseUri = "http://substationservice.azurewebsites.net/api/substations/";


        //**************************************************//
        // GET: api/SubStations: To get all sub stations
        public async Task<HttpResponseMessage> GetSubStations()
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
        } //ends GetSubStations method


        //**************************************************//
        // GET: api/SubStations/5: To get an individual sub station
        [ResponseType(typeof(SubStation))]
        public async Task<IHttpActionResult> GetSubStation(int id)
        {
            //variables
            string uri = baseUri + id; //variabe for the uri for call to external Web API
            HttpResponseMessage response = new HttpResponseMessage(); //variable for Http response
            SubStation subStation = new SubStation(); //variable for the sub station to return

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.GetAsync(uri);
            }

            //assign returning data to object
            if (response.IsSuccessStatusCode)
            {
                subStation = await response.Content.ReadAsAsync<SubStation>();
            }

            //if sub station does not exist return not found
            if (subStation == null)
            {
                return NotFound();
            }

            return Ok(subStation);
        } //ends GetSubStation method


        //**************************************************//
        // PUT: api/SubStations/5: To update an existing sub station
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubStation(int id, SubStation subStation)
        {
            //check Model State is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check ids match
            if (id != subStation.Id)
            {
                return BadRequest();
            }

            //variabe for the uri for call to external Web API
            string uri = baseUri + id;

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(uri, subStation);
            }

            return StatusCode(HttpStatusCode.NoContent);
        } //ends Put method
        

        //**************************************************//
        // POST: api/SubStations: To create a new sub station
        [ResponseType(typeof(SubStation))]
        public async Task<IHttpActionResult> PostSubStation(SubStation subStation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //variabe for the uri for call to external Web API
            string uri = baseUri;
            SubStation newSubStation = new SubStation();

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(uri, subStation);

                if (response.IsSuccessStatusCode)
                {
                    // Get the URI of the created resource.
                    newSubStation = await response.Content.ReadAsAsync<SubStation>();

                    //return new staff member
                    return CreatedAtRoute("DefaultApi", new { id = newSubStation.Id }, newSubStation);
                }
            }
            return BadRequest(ModelState);
        } //ends Post method


        //**************************************************//
        // DELETE: api/SubStation/5: To delete a sub station
        [ResponseType(typeof(SubStation))]
        public async Task<IHttpActionResult> DeleteSubStation(int id)
        {
            //variables
            string uri = baseUri + id; //variabe for the uri for call to external Web API
            HttpResponseMessage response = new HttpResponseMessage(); //variable for Http response
            SubStation subStation = new SubStation(); //variable for the sub station to return

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                //check sub station exists
                response = await httpClient.GetAsync(uri);

                //if it exists
                if (response.IsSuccessStatusCode)
                {
                    //assign result to sub station object
                    subStation = await response.Content.ReadAsAsync<SubStation>();
                    //delete sub station
                    response = await httpClient.DeleteAsync(uri);
                }
                //otherwise return not found
                else
                {
                    return NotFound();
                }
            }
            return Ok(subStation);
        } //ends Delete method

    } //ends class
}