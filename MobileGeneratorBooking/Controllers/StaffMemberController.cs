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
    public class StaffMemberController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://bookingservice.azurewebsites.net/api/staffmembers";
        
        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public StaffMemberController()
        {
            client = new HttpClient();  
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
        }


        //*********************************************************************//
        // GET All: StaffMember
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var StaffMembers = JsonConvert.DeserializeObject<List<StaffMember>>(responseData);

                return View(StaffMembers);
            }
            return View("Error");
        }


        //*********************************************************************//
        // GET All: Operators
        public async Task<ActionResult> Operators()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var StaffMembers = JsonConvert.DeserializeObject<List<StaffMember>>(responseData);
                List<StaffMember> operators = new List<StaffMember>();

                foreach (var s in StaffMembers)
                {
                    if (s.Operator == true)
                    {
                        operators.Add(s);
                    }
                }

                return View(operators);
            }
            return View("Error");
        }


        //*********************************************************************//
        // GET All: Traffic Managers
        public async Task<ActionResult> TrafficManagers()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var StaffMembers = JsonConvert.DeserializeObject<List<StaffMember>>(responseData);
                List<StaffMember> trafficManagers = new List<StaffMember>();

                foreach (var s in StaffMembers)
                {
                    if (s.Traffic == true)
                    {
                        trafficManagers.Add(s);
                    }
                }

                return View(trafficManagers);
            }
            return View("Error");
        }



        //*********************************************************************//
        // Get One: StaffMember
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var staffMember = JsonConvert.DeserializeObject<StaffMember>(responseData);

                return View(staffMember);
            }
            return View("Error");
        }


        //*********************************************************************//
        //Edit: StaffMember
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var staffMember = JsonConvert.DeserializeObject<StaffMember>(responseData);

                return View(staffMember);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, StaffMember staffMember)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, staffMember);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Create: StaffMember
        public ActionResult Create()
        {
            return View(new StaffMember());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(StaffMember staffMember)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, staffMember);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Delete: StaffMember
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var staffMember = JsonConvert.DeserializeObject<StaffMember>(responseData);

                return View(staffMember);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, StaffMember staffMember)
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