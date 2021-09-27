using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleManagement.Services;
using PeopleManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PeopleManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;
        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public IActionResult GetAll(int amount, int skip)
        {
            return Ok(_peopleService.GetAll(amount, skip));
        }

        [HttpGet]
        [Route("singles")]
        public IActionResult GetSingles(int amount, int skip)
        {
            return Ok(_peopleService.GetAll(amount, skip));
        }

        [HttpGet]
        [Route("Seed")]
        public IActionResult Seed(int amount)
        {
            return Ok(_peopleService.Seed(amount));
        }
    }
}
