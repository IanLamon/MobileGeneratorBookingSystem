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
    [Authorize]
    public class CostsController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://bookingservice.azurewebsites.net/api/costs";
        
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public CostsController()
        {
            client = new HttpClient();  
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }


        //*********************************************************************//
        // GET All: Costs
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Costss = JsonConvert.DeserializeObject<List<Costs>>(responseData);

                return View(Costss);
            }
            return View("Error");
        }


        //*********************************************************************//
        // Get One: Costs
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var costs = JsonConvert.DeserializeObject<Costs>(responseData);

                return View(costs);
            }
            return View("Error");
        }


        //*********************************************************************//
        //Edit: Costs
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var costs = JsonConvert.DeserializeObject<Costs>(responseData);

                return View(costs);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Costs costs)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, costs);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Create: Costs
        public ActionResult Create()
        {
            return View(new Costs());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Costs costs)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, costs);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Delete: Costs
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var costs = JsonConvert.DeserializeObject<Costs>(responseData);

                return View(costs);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Costs costs)
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