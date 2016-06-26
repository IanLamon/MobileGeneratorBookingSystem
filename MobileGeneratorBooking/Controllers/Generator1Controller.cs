using MobileGeneratorBooking.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MobileGeneratorBooking.Controllers
{
    public class Generator1Controller : Controller
    {
        HttpClient client;
        //The URL of the OData Service
        string url = "http://bookingservice.azurewebsites.net/odata/Generators1";
        
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public Generator1Controller()
        {
            client = new HttpClient();  
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }


        //*********************************************************************//
        // GET All: Generator
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                //var outerData = JsonConvert.DeserializeObject<OData<string>>(responseData);
                //var generators = JsonConvert.DeserializeObject<List<Generator>>(outerData.value);

                var generators = JObject.Parse(responseData).SelectToken("value").ToObject<List<Generator>>();

                //return View(generators);
                return View("~/Views/Generator/Index.cshtml", generators);
            }
            return View("Error");
        }


        //*********************************************************************//
        // Get One: Generator
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "(" + id + ")");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var generator = JsonConvert.DeserializeObject<Generator>(responseData);

                return View("~/Views/Generator/Details.cshtml", generator);
            }
            return View("Error");
        }


        //*********************************************************************//
        //Edit: Generator
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "(" + id + ")");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var generator = JsonConvert.DeserializeObject<Generator>(responseData);

                return View(generator);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Generator generator)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "(" + id + ")", generator);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("~/Views/Generator/Index.cshtml");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
    }
}