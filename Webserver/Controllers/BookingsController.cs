using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebSite.Controllers
{
    public class BookingsController : Controller
    {

        private IWhatToWatchApiClient _client;

        public BookingsController(IWhatToWatchApiClient client)
        {
            _client = client;
        }

        // GET: BookingsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _client.GetBookingByIdAsync(id));
        }

        // GET: BookingsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(BookingDto booking)
        {
            try
            {
                if (await _client.CreateBookingAsync(booking) > 0)
                {
                    TempData["Message"] = $"Booking for {booking.Date} has been confirmed.";
                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Failed to confirm booking!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }
    }
}
