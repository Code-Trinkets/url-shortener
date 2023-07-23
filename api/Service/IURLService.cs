using System;
using model;

namespace service
{
    public interface IURLService
    {
        public Task<APIResponse> GenerateShortURLMethod(string longUrl);
    }
}

