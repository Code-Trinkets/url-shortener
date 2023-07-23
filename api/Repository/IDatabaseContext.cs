using System;
using MongoDB.Bson;

namespace repository
{
    public interface IDatabaseContext
    {
        public Task<ObjectId> AddURLToDatabase(string longURL, string shortURL, string identifier);
        public Task<bool> CheckIdentifierExists(string identifier);
        public Task<string?> GetLongURL(string identifier);
    }
}

