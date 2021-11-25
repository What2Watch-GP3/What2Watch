using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        //GET: BookingsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _client.GetBookingByIdAsync(id));
        }

        //GET: BookingsController/Confirm
        //TODO: Review the return value when the method is implemented
        public ActionResult Confirm()
        {
            //TODO Implement actual values instead of hardcoded
            TempData["SeatIds"] = new List<int>() { 1, 2, 3 };
            TempData["TotalPrice"] = 40m;
            TempData["Date"] = DateTime.Now;
            return View();
        }

        // POST: BookingsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Confirm(string answer)
        {
            try
            {
                if (answer == "Decline")
                {
                    return RedirectToAction(nameof(Index), "Home");
                }

                //TODO Implement getting the seat ids instead of hardcode
                BookingDto bookings = new() { SeatIds = new List<int>() { 1, 2, 3 }, ShowId = 1 };
                int id = await _client.ConfirmBookingAsync(bookings);
                if (id > 0)
                {
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
