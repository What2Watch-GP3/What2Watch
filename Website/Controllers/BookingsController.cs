using Microsoft.AspNetCore.Authorization;
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
        private IWebApiClient _client;

        public BookingsController(IWebApiClient client)
        {
            _client = client;
        }

        // GET: BookingsController/Details/5
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            return View(await _client.GetBookingByIdAsync(id));
        }

        // GET: BookingsController/Confirm
        [HttpGet]
        public async Task<ActionResult> Confirm()
        {
            //TODO Implement actual values instead of hardcoded
            TempData["SeatIds"] = new List<int>() { 1, 2, 3 };
            TempData["TotalPrice"] = 40;
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
                    return RedirectToAction(nameof(Index), "Movies");
                }

                //TODO Implement getting the seat ids instead of hardcode
                BookingDto bookings = new() { SeatIds = new List<int>() { 1, 2, 3 }, ShowId = 1 };
                int id = await _client.ConfirmBookingAsync(bookings);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Index), "Movies");
                }
                else if (id == -403)
                {
                    TempData["ErrorMessage"] = "You are not logged in!";
                    return RedirectToAction("Login", "Login", new { returnUrl = Request.Path.Value});
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
