using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.DTOs;

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
            if (HttpContext.User != null && HttpContext.User.Identity != null && HttpContext.User.Identity.IsAuthenticated)
            {
                var claim = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type.Equals("access-token")).Value;
                _client.addToken(claim.ToString());
            }
            var movies = await _client.GetAllMoviesAsync();
            
            ViewBag.TextValue = "";
            var titleDictionary = movies.ToDictionary(movie => movie.Id, movie => movie.Title);
            TempData["TitleDictionary"] = JsonConvert.SerializeObject(titleDictionary);
            TempData.Keep();


            var rawValue = ViewData["userData"] as UserDto;
            if (rawValue != null)
            {
                UserDto smth = rawValue;
                TempData.Keep();
            }
            return View(movies);
        }

        private object FirstOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
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
