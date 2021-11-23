using DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;

namespace WebSite.Controllers
{
    [Route("[controller]")]
    public class MoviesController : Controller
    {
        IWhatToWatchApiClient _client;

        public MoviesController(IWhatToWatchApiClient client)
        {
            _client = client;
        }

        // GET: MoviesController
        /*
        public ActionResult Index()
        {

            return RedirectToRoute;
        }*/

        // GET: MoviesController/Details/5
        

        // GET: MoviesController/Details/5
        [HttpGet]
        [Route("{search?}")]
        public async Task<ActionResult> Index(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                ViewBag.TextValue = "a";
                return View(await _client.GetAllMoviesAsync());
            }
            else
            {
                ViewBag.TextValue = search;
                return View(await _client.GetMoviesByPartOfNameAsync(search));
            }
        }

        //TODO: possibly delete
        /*[HttpGet]
        [Route("[controller]/{search}")]
        public async Task<ActionResult> Movies(string search)
        {
            ViewData["CurrentFilter"] = search;
  
            var movies = await _client.GetMoviesByPartOfNameAsync(search);
            return View("Index", movies);
   
        }*/

        /*
        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
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

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoviesController/Edit/5
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

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MoviesController/Delete/5
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
        }*/
    }
}
