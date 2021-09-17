using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuickTechApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace QuickTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechController : ControllerBase
    {
        private ITechService _techService;
        public TechController(ITechService techService)
        {
            _techService = techService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_techService.GetAll());
        }
    }
}
