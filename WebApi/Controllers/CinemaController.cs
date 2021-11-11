﻿using DataAccess.DataAccess;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController : ControllerBase
    {


        ICinemaDataAccess _cinemaDataAccess;

        public CinemaController(IConfiguration configuration)
        {
            _cinemaDataAccess = new CinemaDataAccess(configuration.GetConnectionString("DefaultConnection"));

        }
        // GET: api/<CinemaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CinemaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CinemaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CinemaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CinemaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
