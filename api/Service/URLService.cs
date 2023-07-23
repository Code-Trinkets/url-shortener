using System;
using Microsoft.Extensions.Configuration;
using repository;

namespace service
{
    public class URLService : IURLService
    {
        #region class fields and constructor
        private readonly IConfiguration configuration;
        private readonly IDatabaseContext context;

        public URLService(IConfiguration configuration, IDatabaseContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }
        #endregion
    }
}

