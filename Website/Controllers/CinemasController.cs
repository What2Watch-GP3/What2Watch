using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

namespace WebSite.Controllers
{
    [Route("[controller]")]
    public class CinemasController : Controller
    {
        // GET: CinemasController
        IWebApiClient _client;

        public CinemasController(IWebApiClient client)
        {
            _client = client;
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: CinemasController/Details/5
        [HttpGet]
        public async Task<ActionResult> Cinemas(int movieId)
        {
            IEnumerable<CinemaDto> cinemas = await _client.GetCinemasByMovieIdAsync(movieId);
            MovieDto movieDto = await _client.GetMovieByIdAsync(movieId);
            //List<Task> tasks = new()
            //{
            //    Task.Run(() => _client.GetCinemasByMovieIdAsync(movieId)),
            //    Task.Run(() => _client.GetMovieByIdAsync(movieId))
            //};
            //await Task.WhenAll(tasks);
            //var cinemaNameDictionary = cinemas.ToDictionary(cinema => cinema.Id, cinema => cinema.Name);
            //TempData["CinemaNameDictionary"] = JsonConvert.SerializeObject(cinemaNameDictionary);
            //TempData.Keep();

            dynamic model = new ExpandoObject();
            model.Cinemas = cinemas;
            model.MovieTitle = movieDto.Title;
            model.MovieId = movieDto.Id;
            return View(model);
        }
        /*
        // GET: CinemasController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: CinemasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Movies", "Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CinemasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CinemasController/Edit/5
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

        // GET: CinemasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CinemasController/Delete/5
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
