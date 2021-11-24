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
    public class ShowsController : Controller
    {

        IWhatToWatchApiClient _client;
        public ShowsController(IWhatToWatchApiClient client)
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
        public async Task <ActionResult> Shows(int movieId, int cinemaId)
        {

            TempData["cinemaId"] = cinemaId;
            TempData["movieId"] = movieId;
            return View(await _client.GetShowsByMovieAndCinemaIdAsync(movieId,cinemaId));
        }

       

        // GET: ShowsController/Create
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
        }
    }
}
