using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;


namespace WebSite.Controllers
{

    [Route("[controller]")]
    public class CinemasController : Controller
    {
        // GET: CinemasController
        IWhatToWatchApiClient _client;

        public CinemasController(IWhatToWatchApiClient client)
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
            var cinemas = await _client.GetCinemasByMovieIdAsync(movieId);
            TempData["movieId"] = movieId;
            var nameDictionary = cinemas.ToDictionary(cinema => cinema.Id, cinema => cinema.Name);
            TempData["nameDictionary"] = JsonConvert.SerializeObject(nameDictionary);
            return View(cinemas);
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
                return RedirectToAction(nameof(Index));
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
