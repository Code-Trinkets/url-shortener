using System;
using model;

namespace service
{
    public interface IURLService
    {
        public Task<APIResponse> GenerateShortURLMethod(string longUrl);
        public Task<APIResponse> GetLongURLMethod(string identifier);
    }
}

