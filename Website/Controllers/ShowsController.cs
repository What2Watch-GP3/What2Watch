using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebSite.Controllers
{
    [Route("[controller]")]
    public class ShowsController : Controller
    {
        IWebApiClient _client;
        public ShowsController(IWebApiClient client)
        {
            _client = client;
        }

        // GET: ShowsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShowsController/Details/5
        [HttpGet]
        public async Task<ActionResult> Shows(int movieId, int cinemaId)
        {
            MovieDto movie = await _client.GetMovieByIdAsync(movieId);
            CinemaDto cinema = await _client.GetCinemaByIdAsync(cinemaId);
            IEnumerable<ShowDto> shows = await _client.GetShowsByMovieAndCinemaIdAsync(movieId, cinemaId);
            dynamic model = new ExpandoObject();
            model.MovieTitle = movie.Title;
            model.CinemaName = cinema.Name;
            model.Shows = shows;
            return View(model);
        }

        /* GET: ShowsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShowsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShowsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        } */
    }
}
