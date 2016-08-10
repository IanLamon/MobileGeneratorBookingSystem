using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BookingApplication.Models;

namespace BookingApplication.Controllers
{
    public class BookingController : Controller
    {
        HttpClient client;
        //The URL of the WEB API Service
        string url = "http://bookingservice.azurewebsites.net/api/bookings";

        //The HttpClient Class, this will be used for performing 
        //HTTP Operations, GET, POST, PUT, DELETE
        //Set the base address and the Header Formatter
        public BookingController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        //*********************************************************************//
        // GET All: Future Bookings
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Bookings = JsonConvert.DeserializeObject<List<Booking>>(responseData).OrderBy(x => x.StartTime);

                var today = DateTime.Today;
                List<Booking> futureBookings = new List<Booking>();

                foreach (var b in Bookings)
                {
                    if (b.StartTime >= today)
                    {
                        futureBookings.Add(b);
                    }
                }

                return View(futureBookings);
            }
            return View("Error");
        }


        //*********************************************************************//
        // GET All: Past Bookings
        public async Task<ActionResult> PastBookings()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Bookings = JsonConvert.DeserializeObject<List<Booking>>(responseData).OrderByDescending(x => x.StartTime);

                var today = DateTime.Today;
                List<Booking> pastBookings = new List<Booking>();

                foreach (var b in Bookings)
                {
                    if (b.StartTime < today)
                    {
                        pastBookings.Add(b);
                    }
                }

                return View(pastBookings);
            }
            return View("Error");
        }


        //*********************************************************************//
        // GET Calendar Data: Booking
        public async Task<ActionResult> Calendar(int inMonth = 0, int inYear = 0)
        {
            DateTime now = DateTime.Now;

            HttpResponseMessage responseMessage = await client.GetAsync(url);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Bookings = JsonConvert.DeserializeObject<List<Booking>>(responseData);
                var year = now.Year;
                var month = now.Month + inMonth;
                var curMonthData = new List<Booking>();

                foreach (var b in Bookings)
                {
                    if (b.StartTime.Year == year && b.StartTime.Month == month)
                    {
                        curMonthData.Add(b);
                    }
                }

                return View(curMonthData);
            }
            return View("Error");
        }

        //*********************************************************************//
        // Get One: Booking
        public async Task<ActionResult> Details(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var booking = JsonConvert.DeserializeObject<Booking>(responseData);

                return View(booking);
            }
            return View("Error");
        }


        //*********************************************************************//
        //Edit: Booking
        public async Task<ActionResult> Edit(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var booking = JsonConvert.DeserializeObject<Booking>(responseData);

                return View(booking);
            }
            return View("Error");
        }

        //The PUT Method
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Booking booking)
        {
            HttpResponseMessage responseMessage = await client.PutAsJsonAsync(url + "/" + id, booking);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Create: Booking
        public ActionResult Create()
        {
            return View(new Booking());
        }

        //The Post method
        [HttpPost]
        public async Task<ActionResult> Create(Booking booking)
        {
            HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url, booking);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }


        //*********************************************************************//
        //Delete: Booking
        public async Task<ActionResult> Delete(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var booking = JsonConvert.DeserializeObject<Booking>(responseData);

                return View(booking);
            }
            return View("Error");
        }

        //The DELETE method
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Booking booking)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync(url + "/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
    //public class BookingController : Controller
    //{
    //    private ApplicationDbContext db = new ApplicationDbContext();

    //    // GET: Booking
    //    public ActionResult Index()
    //    {
    //        var bookings = db.Bookings.Include(b => b.Approver).Include(b => b.Generator).Include(b => b.Operator1).Include(b => b.Operator2).Include(b => b.SubStation).Include(b => b.TrafficManager);
    //        return View(bookings.ToList());
    //    }

    //    // GET: Booking/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Booking booking = db.Bookings.Find(id);
    //        if (booking == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(booking);
    //    }

    //    // GET: Booking/Create
    //    public ActionResult Create()
    //    {
    //        ViewBag.ApproverId = new SelectList(db.StaffMembers, "Id", "FirstName");
    //        ViewBag.GeneratorId = new SelectList(db.Generators, "Id", "Name");
    //        ViewBag.Operator1Id = new SelectList(db.StaffMembers, "Id", "FirstName");
    //        ViewBag.Operator2Id = new SelectList(db.StaffMembers, "Id", "FirstName");
    //        ViewBag.SubstationId = new SelectList(db.SubStations, "Id", "Name");
    //        ViewBag.TrafficManagerId = new SelectList(db.StaffMembers, "Id", "FirstName");
    //        return View();
    //    }

    //    // POST: Booking/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "Id,BookingType,StartTime,FinishTime,WBSNumber,SpecialInstructions,BookingStatus,CustomersAffected,CostPerCustomer,CostPerHour,CostOfGeneratorPerDay,DieselCostPerLitre,GeneratorDieselLitres,TruckDieselLitres,GeneratorId,SubstationId,Operator1Id,Operator2Id,TrafficManagerId,ApproverId")] Booking booking)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Bookings.Add(booking);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        ViewBag.ApproverId = new SelectList(db.StaffMembers, "Id", "FirstName", booking.ApproverId);
    //        ViewBag.GeneratorId = new SelectList(db.Generators, "Id", "Name", booking.GeneratorId);
    //        ViewBag.Operator1Id = new SelectList(db.StaffMembers, "Id", "FirstName", booking.Operator1Id);
    //        ViewBag.Operator2Id = new SelectList(db.StaffMembers, "Id", "FirstName", booking.Operator2Id);
    //        ViewBag.SubstationId = new SelectList(db.SubStations, "Id", "Name", booking.SubstationId);
    //        ViewBag.TrafficManagerId = new SelectList(db.StaffMembers, "Id", "FirstName", booking.TrafficManagerId);
    //        return View(booking);
    //    }

    //    // GET: Booking/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Booking booking = db.Bookings.Find(id);
    //        if (booking == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        ViewBag.ApproverId = new SelectList(db.StaffMembers, "Id", "FirstName", booking.ApproverId);
    //        ViewBag.GeneratorId = new SelectList(db.Generators, "Id", "Name", booking.GeneratorId);
    //        ViewBag.Operator1Id = new SelectList(db.StaffMembers, "Id", "FirstName", booking.Operator1Id);
    //        ViewBag.Operator2Id = new SelectList(db.StaffMembers, "Id", "FirstName", booking.Operator2Id);
    //        ViewBag.SubstationId = new SelectList(db.SubStations, "Id", "Name", booking.SubstationId);
    //        ViewBag.TrafficManagerId = new SelectList(db.StaffMembers, "Id", "FirstName", booking.TrafficManagerId);
    //        return View(booking);
    //    }

    //    // POST: Booking/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "Id,BookingType,StartTime,FinishTime,WBSNumber,SpecialInstructions,BookingStatus,CustomersAffected,CostPerCustomer,CostPerHour,CostOfGeneratorPerDay,DieselCostPerLitre,GeneratorDieselLitres,TruckDieselLitres,GeneratorId,SubstationId,Operator1Id,Operator2Id,TrafficManagerId,ApproverId")] Booking booking)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(booking).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        ViewBag.ApproverId = new SelectList(db.StaffMembers, "Id", "FirstName", booking.ApproverId);
    //        ViewBag.GeneratorId = new SelectList(db.Generators, "Id", "Name", booking.GeneratorId);
    //        ViewBag.Operator1Id = new SelectList(db.StaffMembers, "Id", "FirstName", booking.Operator1Id);
    //        ViewBag.Operator2Id = new SelectList(db.StaffMembers, "Id", "FirstName", booking.Operator2Id);
    //        ViewBag.SubstationId = new SelectList(db.SubStations, "Id", "Name", booking.SubstationId);
    //        ViewBag.TrafficManagerId = new SelectList(db.StaffMembers, "Id", "FirstName", booking.TrafficManagerId);
    //        return View(booking);
    //    }

    //    // GET: Booking/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Booking booking = db.Bookings.Find(id);
    //        if (booking == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(booking);
    //    }

    //    // POST: Booking/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Booking booking = db.Bookings.Find(id);
    //        db.Bookings.Remove(booking);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}
}
