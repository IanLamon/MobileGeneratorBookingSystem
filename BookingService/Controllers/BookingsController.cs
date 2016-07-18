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
    public class BookingsController : ApiController
    {
        private BookingServiceContext db = new BookingServiceContext();

        // GET: api/Bookings
        //public IQueryable<Booking> GetBookings()
        //{
        //    return db.Bookings;
        //}

        public IQueryable<Booking> GetBookings()
        {

            List<Booking> listOfBookings = new List<Booking>();

            foreach (var b in db.Bookings)
            {
                Booking booking = new Booking();

                booking.Id = b.Id;
                booking.BookingType = b.BookingType;
                booking.StartTime = b.StartTime;
                booking.FinishTime = b.FinishTime;
                booking.WBSNumber = b.WBSNumber;
                booking.SpecialInstructions = b.SpecialInstructions;
                booking.BookingStatus = b.BookingStatus;
                booking.CustomersAffected = b.CustomersAffected;
                booking.CostPerCustomer = b.CostPerCustomer;
                booking.CostPerHour = b.CostPerHour;
                booking.CostOfGeneratorPerDay = b.CostOfGeneratorPerDay;
                booking.DieselCostPerLitre = b.DieselCostPerLitre;
                booking.GeneratorDieselLitres = b.GeneratorDieselLitres;
                booking.TruckDieselLitres = b.TruckDieselLitres;

                //Foreign Keys
                booking.GeneratorId = b.GeneratorId;
                booking.SubstationId = b.SubstationId;
                booking.Operator1Id = b.Operator1Id;
                booking.Operator2Id = b.Operator2Id;
                booking.TrafficManagerId = b.TrafficManagerId;
                booking.ApproverId = b.ApproverId;

                //Navigation Keys
                //booking.Generator = b.Generator;
                //booking.SubStation = b.SubStation;
                //booking.Operator1 = b.Operator1;
                //booking.Operator2 = b.Operator2;
                //booking.TrafficManager = b.TrafficManager;
                //booking.Approver = b.Approver;

                listOfBookings.Add(booking);
            }
            IQueryable<Booking> bookings = listOfBookings.AsQueryable();

            return bookings;

        }


        // GET: api/Bookings : To get all bookings for a specified month
        public IQueryable<Booking> GetBookings(int year, int month)
        {

            List<Booking> listOfBookings = new List<Booking>();

            foreach (var b in db.Bookings)
            {
                if (b.StartTime.Year == year && b.StartTime.Month == month)
                {
                    Booking booking = new Booking();

                    booking.Id = b.Id;
                    booking.BookingType = b.BookingType;
                    booking.StartTime = b.StartTime;
                    booking.FinishTime = b.FinishTime;
                    booking.WBSNumber = b.WBSNumber;
                    booking.SpecialInstructions = b.SpecialInstructions;
                    booking.BookingStatus = b.BookingStatus;
                    booking.CustomersAffected = b.CustomersAffected;
                    booking.CostPerCustomer = b.CostPerCustomer;
                    booking.CostPerHour = b.CostPerHour;
                    booking.CostOfGeneratorPerDay = b.CostOfGeneratorPerDay;
                    booking.DieselCostPerLitre = b.DieselCostPerLitre;
                    booking.GeneratorDieselLitres = b.GeneratorDieselLitres;
                    booking.TruckDieselLitres = b.TruckDieselLitres;

                    //Foreign Keys
                    booking.GeneratorId = b.GeneratorId;
                    booking.SubstationId = b.SubstationId;
                    booking.Operator1Id = b.Operator1Id;
                    booking.Operator2Id = b.Operator2Id;
                    booking.TrafficManagerId = b.TrafficManagerId;
                    booking.ApproverId = b.ApproverId;

                    listOfBookings.Add(booking);
                }

            }
            IQueryable<Booking> bookings = listOfBookings.AsQueryable();

            return bookings;

        }


        // GET: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public async Task<IHttpActionResult> GetBooking(int id)
        {
            Booking b = await db.Bookings.FindAsync(id); //entity from database
            Booking booking = new Booking(); //object to return

            if (b == null)
            {
                return NotFound();
            }
            else
            {
                booking.Id = b.Id;
                booking.BookingType = b.BookingType;
                booking.StartTime = b.StartTime;
                booking.FinishTime = b.FinishTime;
                booking.WBSNumber = b.WBSNumber;
                booking.SpecialInstructions = b.SpecialInstructions;
                booking.BookingStatus = b.BookingStatus;
                booking.CustomersAffected = b.CustomersAffected;
                booking.CostPerCustomer = b.CostPerCustomer;
                booking.CostPerHour = b.CostPerHour;
                booking.CostOfGeneratorPerDay = b.CostOfGeneratorPerDay;
                booking.DieselCostPerLitre = b.DieselCostPerLitre;
                booking.GeneratorDieselLitres = b.GeneratorDieselLitres;
                booking.TruckDieselLitres = b.TruckDieselLitres;

                //Foreign Keys
                booking.GeneratorId = b.GeneratorId;
                booking.SubstationId = b.SubstationId;
                booking.Operator1Id = b.Operator1Id;
                booking.Operator2Id = b.Operator2Id;
                booking.TrafficManagerId = b.TrafficManagerId;
                booking.ApproverId = b.ApproverId;

                //Navigation Keys
                booking.Generator = b.Generator;
                booking.SubStation = b.SubStation;
                booking.Operator1 = b.Operator1;
                booking.Operator2 = b.Operator2;
                booking.TrafficManager = b.TrafficManager;
                booking.Approver = b.Approver;
            }

            return Ok(booking);
        }

        // PUT: api/Bookings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBooking(int id, Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking.Id)
            {
                return BadRequest();
            }

            db.Entry(booking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Bookings
        [ResponseType(typeof(Booking))]
        public async Task<IHttpActionResult> PostBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = booking.Id }, booking);
        }

        // DELETE: api/Bookings/5
        [ResponseType(typeof(Booking))]
        public async Task<IHttpActionResult> DeleteBooking(int id)
        {
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            db.Bookings.Remove(booking);
            await db.SaveChangesAsync();

            return Ok(booking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookingExists(int id)
        {
            return db.Bookings.Count(e => e.Id == id) > 0;
        }
    }
}