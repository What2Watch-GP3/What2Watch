using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        //TODO: consider adding a collection of reservationDTOs as a parameter
        //[Route("[action]")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Confirm(IEnumerable<ReservationDto> reservationDtos)
        {
            dynamic model = new ExpandoObject();
            if (!reservationDtos.Any())
            {
                //var reservations = await _client.GetReservationsAsync();
                //model.Reservations = reservations;
                //model.ResCount = reservations.ToList().Count;
                model.ResCount = JsonConvert.DeserializeObject<IEnumerable<string>>(TempData.Peek("SelectedSeatPositions").ToString()).ToList().Count;
            }
            else
            {
                model.Reservations = reservationDtos;
            }
            model.TotalPrice = _client.GetTotalPrice(JsonConvert.DeserializeObject<IEnumerable<string>>(TempData.Peek("SelectedSeatPositions").ToString()));
            var showDto = _client.GetShowById((int)TempData.Peek("ShowId"));
            model.Date = showDto.StartTime;
            var movie = await _client.GetMovieByIdAsync(1);
            model.MovieTitle = movie.Title;

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

                //var reservationDtos = JsonConvert.DeserializeObject<IEnumerable<ReservationDto>>(TempData["reservations"].ToString());
                //TODO Implement getting the seat ids instead of hardcode
                BookingDto booking = new()
                {
                    TotalPrice = _client.GetTotalPrice(JsonConvert.DeserializeObject<IEnumerable<string>>(TempData["SelectedSeatPositions"].ToString())),
                    Date = DateTime.Now,
                    //ShowId = reservationDtos.ToList().FirstOrDefault().ShowId,
                    ShowId = (int)TempData.Peek("ShowId"),
                    //TODO: redirect to login page if user is logged in 
                    UserId = User.Identity.Name != null ? Convert.ToInt32(User.Claims.FirstOrDefault(claim => claim.Type == "user-id").Value) : 0,
                    //TicketIds = reservationDtos.ToList().Select(reservation => reservation.Id).ToList()
                };
                
                int id = await _client.ConfirmBookingAsync(booking);
                if (id > 0)
                {
                    return RedirectToAction(nameof(Index), "Movies");
                }
                else if (id == -403)
                {
                    ViewBag.ErrorMessage = "You are not logged in!";
                    return RedirectToAction("Login", "Users", new { returnUrl = Request.Path.Value});
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
