using System;
using MongoDB.Bson;

namespace repository
{
    public interface IDatabaseContext
    {
        public Task<ObjectId> AddURLToDatabase(string longURL, string shortURL);
    }
}

