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
    public class SubStations1Controller : ODataController
    {
        //The URL of the WEB API Service
        readonly string baseUri = "http://substationservice.azurewebsites.net/odata/SubStations1";


        //**************************************************//
        // GET: odata/SubStations1: To get all sub stations
        public async Task<HttpResponseMessage> GetSubStations1()
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
        // GET: odata/SubStations1(5): To get an individual sub station
        [ResponseType(typeof(SubStation))]
        public async Task<IHttpActionResult> GetSubStation([FromODataUri]int key)
        {
            //variables
            string uri = baseUri + "(" + key + ")"; //variabe for the uri for call to external Web API
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
        // PUT: odata/SubStations1(5): To update an existing sub station
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Delta<SubStation> patch)
        {
            //check Model State is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //variabe for the uri for call to external Web API
            string uri = baseUri + "(" + key + ")";
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

            //External Web API call
            using (HttpClient httpClient = new HttpClient())
            {
                response = await httpClient.PutAsJsonAsync(uri, patch);
            }

            return Updated(subStation);
        } //ends Put method


        //**************************************************//
        // POST: odata/SubStations1: To create a new sub station
        public async Task<IHttpActionResult> Post(SubStation subStation)
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

                    //return new sub station
                    return Created(subStation);
                }
            }
            return BadRequest(ModelState);
        } //ends Post method


        //**************************************************//
        //// PATCH: odata/SubStations1(5)
        //[AcceptVerbs("PATCH", "MERGE")]
        //public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<SubStation> patch)
        //{
        //    Validate(patch.GetEntity());

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    SubStation subStation = await db.SubStations.FindAsync(key);
        //    if (subStation == null)
        //    {
        //        return NotFound();
        //    }

        //    patch.Patch(subStation);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SubStationExists(key))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return Updated(subStation);
        //}


        //**************************************************//
        // DELETE: odata/SubStations1(5): To delete a sub station
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            //variables
            string uri = baseUri + "(" + key + ")"; //variabe for the uri for call to external Web API
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
                    //delete sub station
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

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool SubStationExists(int key)
        //{
        //    return db.SubStations.Count(e => e.Id == key) > 0;
        //}
    }
}
