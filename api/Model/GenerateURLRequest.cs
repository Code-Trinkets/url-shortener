using System;
namespace model
{
    /// <summary>
    /// Information that is needed to generate a new short URL.
    /// </summary>
    public class GenerateURLRequest
    {
        /// <summary>
        /// The long URL that is to be shortened
        /// <example>https://thisisaveeeeeeeerylongurl.com</example>
        /// </summary>
        public required string LongURL { get; set; }
    }
}

