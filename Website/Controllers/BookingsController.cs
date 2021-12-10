﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
            dynamic model = new ExpandoObject();

            model.TotalPrice = _client.GetTotalPrice(JsonConvert.DeserializeObject<IEnumerable<string>>(TempData.Peek("SelectedSeatPositions").ToString()));
            model.Date = _client.GetShowById((int)TempData.Peek("ShowId")).StartTime;
            return View(model);
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
                BookingDto bookings = new()
                {
                    TotalPrice = _client.GetTotalPrice(JsonConvert.DeserializeObject<IEnumerable<string>>(TempData["SelectedSeatPositions"].ToString())),
                    Date = DateTime.Now,
                    ShowId = (int)TempData["ShowId"],
                    UserId = 1 //TODO: maybe this: this.User.Claims.First(claim => claim.Type == "UserId").Value;
                };
                
                int id = await _client.ConfirmBookingAsync(bookings);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Index), "Movies");
                }
                else if (id == -403)
                {
                    ViewBag.ErrorMessage = "You are not logged in!";
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
