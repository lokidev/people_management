using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleManagement.Services;
using PeopleManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PeopleManagement.Models.Requests;

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
        public IActionResult GetAll()
        {
            return Ok(_peopleService.GetAll());
        }

        [HttpGet]
        [Route("paged")]
        public IActionResult GetAll(int amount, int skip)
        {
            return Ok(_peopleService.GetAll(amount, skip));
        }

        [HttpGet]
        [Route("allEverCount")]
        public IActionResult GetAllEverCount()
        {
            return Ok(_peopleService.GetAllEverCount());
        }

        [HttpGet]
        [Route("aliveCount")]
        public IActionResult GetAliveCount()
        {
            return Ok(_peopleService.GetAliveCount());
        }

        [HttpGet]
        [Route("deathCount")]
        public IActionResult GetDeathCount()
        {
            return Ok(_peopleService.GetDeathCount());
        }

        [HttpGet]
        [Route("mateCount")]
        public IActionResult GetMateCount()
        {
            return Ok(_peopleService.GetMateCount());
        }

        [HttpPost]
        [Route("ageRangeCount")]
        public IActionResult GetAgeRangeCount(AgeRange ageRangeModel)
        {
            return Ok(_peopleService.GetInAgeRangeCount(ageRangeModel.currentDate, ageRangeModel.MinAge, ageRangeModel.MaxAge));
        }

        [HttpGet]
        [Route("Seed")]
        public IActionResult Seed(int amount)
        {
            return Ok(_peopleService.Seed(amount));
        }
    }
}
