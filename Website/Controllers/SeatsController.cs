using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Controllers
{
    [Route("[controller]")]
    public class SeatsController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Select()
        {
            //TODO: implement later
            dynamic expando = new ExpandoObject();
            expando.Rows = 8;
            expando.SeatsInRow = 10;
            return View(expando);
        }
    }
}
