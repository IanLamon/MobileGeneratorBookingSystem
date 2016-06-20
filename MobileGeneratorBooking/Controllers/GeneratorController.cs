using MobileGeneratorBooking.Models;
using Newtonsoft.Json;
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
    public class GeneratorController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://bookingservice.azurewebsites.net/api/generators";
        
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public GeneratorController()
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

                var Generators = JsonConvert.DeserializeObject<List<Generator>>(responseData);

                return View(Generators);
            }
            return View("Error");
        }


        //*********************************************************************//
        // Get One: Generator
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var generator = JsonConvert.DeserializeObject<Generator>(responseData);

                return View(generator);
            }
            return View("Error");
        }


        //*********************************************************************//
        //Edit: Generator
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
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
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, generator);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Create: Generator
        public ActionResult Create()
        {
            return View(new Generator());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Generator generator)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, generator);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Delete: Generator
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var generator = JsonConvert.DeserializeObject<Generator>(responseData);

                return View(generator);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Generator generator)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        
    }
}