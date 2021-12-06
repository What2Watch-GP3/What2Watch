using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClient;

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
            var room = new { Rows = 8, SeatsPerRow = 10 }; //await _client.GetRoomByShowId(showId);
 
            //TODO: implement later
            dynamic model = new ExpandoObject();
            model.Rows = room.Rows;
            model.SeatsPerRow = room.SeatsPerRow;
            return View(model);
        }
    }
}
