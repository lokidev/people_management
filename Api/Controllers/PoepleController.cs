using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PeopleManagement.Services;
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
        public IActionResult GetAll()
        {
            return Ok(_peopleService.GetAll());
        }
    }
}
