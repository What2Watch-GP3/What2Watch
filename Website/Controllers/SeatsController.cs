using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebSite.Controllers
{
    [Route("[controller]")]
    public class SeatsController : Controller
    {
        IWebApiClient _client;
        public SeatsController(IWebApiClient client)
        {
            _client = client;
        }

        [HttpGet]
        [Route("showId:int")]
        public async Task<ActionResult> Select(int showId, DateTime showStartTime)
        {
            TempData["ShowId"] = showId;
            var room = await _client.GetRoomByShowIdAsync(showId);

            return View(room);
        }

        [HttpPost]
        public async Task<ActionResult> Reserve(IEnumerable<string> selectedSeats)
        {
            List<ReservationDto> reservationDtos = new();
            foreach (var seatPosition in selectedSeats)
            {
                ReservationDto reservation = new()
                {
                    CreationTime = DateTime.Now,
                    SeatPosition = seatPosition,
                    ShowId = (int)TempData.Peek("ShowId"),
                    //if no claim for user-id exists, it means that Convert.ToInt32 will return 0 which will match a service account.
                    //in case you close the session and didn't buy your tickets, your ticket reservation is lost, thus
                    UserId = User.Identity.Name != null ? Convert.ToInt32(User.Claims.FirstOrDefault(claim => claim.Type == "user-id").Value) : 0
                };
                reservationDtos.Add(reservation);
            }
            //TODO:uncomment after implementation of next screen.
            await _client.CreateReservationAsync(reservationDtos);
            return RedirectToAction("Confirm", "Bookings", new { reservationDtos = reservationDtos });
        }

        [HttpGet]
        public ActionResult<decimal> GetTotalPrice(IEnumerable<string> seatPositions)
        {
             TempData["SelectedSeatPositions"] = JsonConvert.SerializeObject(seatPositions);
             return Ok(_client.GetTotalPrice(seatPositions));
        }
    }
}
