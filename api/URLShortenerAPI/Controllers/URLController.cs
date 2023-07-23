using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

    }
}

