using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using model;

namespace repository
{
    public class DatabaseContext : IDatabaseContext
    {
        #region class fields and constructor
        private readonly IConfiguration configuration;
        private readonly string connectionString;
        private readonly IMongoClient client;
        private readonly string databaseName;

        public DatabaseContext(IConfiguration configuration)
        {
            this.configuration = configuration;

            string? connStr = configuration.GetConnectionString("Database");
            string? dbName = configuration.GetValue<string>("DatabaseSettings:DefaultDatabase");

            // Null checks
            if (connStr is null)
                throw new ArgumentNullException(nameof(connStr), "Missing ConnectionStrings:Database appsettings configuration field.");
            if (dbName is null)
                throw new ArgumentNullException(nameof(dbName), "Missing DatabaseSettings:DefaultDatabase appsettings configuration field.");

            this.connectionString = connStr;
            this.databaseName = dbName;

            #region connecting to the database;
            var settings = MongoClientSettings.FromConnectionString(this.connectionString);

            // Set the ServerApi field of the settings object to Stable API version 1
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            // Create a new client and connect to the server
            this.client = new MongoClient(settings);
            #endregion
        }
        #endregion

        public async Task<ObjectId> AddURLToDatabase(string longURL, string shortURL, string identifier)
        {
            // Setting up the data
            URLMapping mapping = new()
            {
                Long = longURL,
                Short = shortURL,
                Identifier = identifier
            };

            // Inserting into the database
            var collection = this.client.GetDatabase(this.databaseName).GetCollection<URLMapping>("urls");

            await collection.InsertOneAsync(mapping);

            return mapping.Id;
        }

        public async Task<bool> CheckIdentifierExists(string identifier)
        {
            var collection = this.client.GetDatabase(this.databaseName).GetCollection<URLMapping>("urls");

            var filter = Builders<URLMapping>.Filter
                .Eq(entry => entry.Identifier, identifier);

            URLMapping? result = await collection.Find(filter).FirstOrDefaultAsync();

            return result is not null;
        }
    }
}

