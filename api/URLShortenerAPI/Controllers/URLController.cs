using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using model;
using service;

namespace URLShortenerAPI.Controllers
{
    [Route("api/[controller]")]
    public class URLController : Controller
    {
        #region class fields and consructor
        private readonly IConfiguration configuration;
        private readonly IURLService service;

        public URLController(IConfiguration configuration, IURLService service)
        {
            this.configuration = configuration;
            this.service = service;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> GenerateShortURL([FromBody] GenerateURLRequest requestInfo)
        {
            APIResponse response;
            try
            {
                response = await service.GenerateShortURLMethod(requestInfo.LongURL);
            }
            catch(Exception ex)
            {
                response = new(StatusCodes.Status500InternalServerError, exception: ex);
            }
            return StatusCode(response.StatusCode, response);
        }
    }
}

