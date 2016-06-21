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

namespace MobileSubStationBooking.Controllers
{
    public class SubStationController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://bookingservice.azurewebsites.net/api/substations";
        
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public SubStationController()
        {
            client = new HttpClient();  
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }


        //*********************************************************************//
        // GET All: SubStation
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var SubStations = JsonConvert.DeserializeObject<List<SubStation>>(responseData);

                return View(SubStations);
            }
            return View("Error");
        }


        //*********************************************************************//
        // Get One: SubStation
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var subStation = JsonConvert.DeserializeObject<SubStation>(responseData);

                return View(subStation);
            }
            return View("Error");
        }


        //*********************************************************************//
        //Edit: SubStation
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var subStation = JsonConvert.DeserializeObject<SubStation>(responseData);

                return View(subStation);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, SubStation subStation)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, subStation);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Create: SubStation
        public ActionResult Create()
        {
            return View(new SubStation());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(SubStation subStation)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, subStation);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Delete: SubStation
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var subStation = JsonConvert.DeserializeObject<SubStation>(responseData);

                return View(subStation);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, SubStation subStation)
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