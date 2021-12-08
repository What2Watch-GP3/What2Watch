using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        public async Task<ActionResult> Select(int showId)
        {
            TempData["showId"] = showId;
            var room = new { Rows = 8, SeatsPerRow = 10 };
            //await _client.GetRoomByShowId(showId);

            //TODO: implement later
            dynamic model = new ExpandoObject();
            model.Rows = room.Rows;
            model.SeatsPerRow = room.SeatsPerRow;
            return View(model);
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
                    ShowId = (int)TempData["showId"],
                    UserId = 1 //TODO: maybe this: this.User.Claims.First(claim => claim.Type == "UserId").Value;
                };
                reservationDtos.Add(reservation);
            }
            await _client.CreateReservationAsync(reservationDtos);
            return RedirectToAction("Confirm", "Bookings");
        }
    }
}
