using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;

namespace WebSite.Controllers
{
    //[Route("{Movies?}")]
    public class MoviesController : Controller
    {
        IWebApiClient _client;

        public MoviesController(IWebApiClient client)
        {
            _client = client;
        }
        //Get method for the Index page
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var movies = await _client.GetAllMoviesAsync();
            
            ViewBag.TextValue = "";
            var titleDictionary = movies.ToDictionary(movie => movie.Id, movie => movie.Title);
            TempData["TitleDictionary"] = JsonConvert.SerializeObject(titleDictionary);
            TempData.Keep();

            return View(movies);
        }

        //Get method for movies/ or movies/{string} or movies?search={string}
        //or if you hit the search bar both in index and in movies/
        [HttpGet]
        [Route("[controller]/{search?}")]
        public async Task<ActionResult> Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {

                var movies = await _client.GetAllMoviesAsync();
                ViewBag.TextValue = "";
                var titleDictionary = movies.ToDictionary(movie => movie.Id, movie => movie.Title);
                TempData["TitleDictionary"] = JsonConvert.SerializeObject(titleDictionary);
                TempData.Keep("TitleDictionary");
                return View(movies);
            }
            else
            {
                ViewBag.TextValue = search;
                return View(await _client.GetMoviesByPartOfNameAsync(search));
            }
        }
    }
}
