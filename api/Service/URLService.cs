using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using model;
using MongoDB.Driver;
using repository;

namespace service
{
    public class URLService : IURLService
    {
        #region class fields and constructor
        private readonly IConfiguration configuration;
        private readonly IDatabaseContext context;

        private readonly int identifierLength;
        private readonly string baseUrl;

        public URLService(IConfiguration configuration, IDatabaseContext context)
        {
            this.configuration = configuration;
            this.context = context;

            int? idLen = this.configuration.GetValue<int>("IDGeneration:NumOfChars");
            string? urlBase = this.configuration.GetValue<string>("IDGeneration:BaseURL");

            // Null checks
            if (idLen is null)
                throw new ArgumentNullException(nameof(idLen), "Missing IDGeneration:NumOfChars appsettings configuration field.");
            if (urlBase is null)
                throw new ArgumentNullException(nameof(urlBase), "Missing IDGeneration:BaseURL appsettings configuration field.");

            this.identifierLength = (int)idLen;
            this.baseUrl = urlBase;
        }
        #endregion

        public async Task<APIResponse> GenerateShortURLMethod(string longUrl)
        {
            string identifier;
            do
            {
                identifier = GenerateRandomIdentifier();
            }
            while (await CheckIdentifierExists(identifier));
            
            string url = this.baseUrl + identifier;

            await this.context.AddURLToDatabase(longUrl, url, identifier);

            return new APIResponse(StatusCodes.Status201Created, url, success: true);
            
        }

        public async Task<APIResponse> GetLongURLMethod(string identifier)
        {
            string? longUrl = await GetLongURL(identifier);

            APIResponse response;
            if (longUrl is null)
                response = new(StatusCodes.Status404NotFound, message: "There was no URL found with that identifier.", success: false);
            else
                response = new(StatusCodes.Status200OK, longUrl, success: true);
            return response;
        }

        #region helpers
        private string GenerateRandomIdentifier()
        {
            Random ran = new();
            int start = (int)Math.Pow(10, this.identifierLength - 1);
            int end = ((int)Math.Pow(10, this.identifierLength))-1;

            char[] identifier = ran.Next(start, end).ToString().ToCharArray();

            for (int i = 0; i < this.identifierLength; i++)
            {
                double chance = ran.NextDouble();
                double roll = ran.NextDouble();

                if (roll < chance)
                {
                    roll = ran.NextDouble();
                    if (roll < chance)
                        identifier[i] = (char)ran.Next(65, 90);
                    else
                        identifier[i] = (char)ran.Next(97, 122);
                }
            }

            return new string(identifier);
        }

        private async Task<bool> CheckIdentifierExists(string identifier)
        {
            return await this.context.CheckIdentifierExists(identifier);
        }

        private async Task<string?> GetLongURL(string identifier)
        {
            return await this.context.GetLongURL(identifier);
        }
        #endregion
    }
}

