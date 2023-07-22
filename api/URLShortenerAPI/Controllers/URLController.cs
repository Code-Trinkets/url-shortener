using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace URLShortenerAPI.Controllers
{
    [Route("api/[controller]")]
    public class URLController : Controller
    {
        [HttpGet]
        public string TestMethod()
        {
            return "Hello World!";
        }
    }
}

