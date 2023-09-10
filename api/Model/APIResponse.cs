using System;

namespace model
{
    public class APIResponse
    {
        public int StatusCode;
        public object? Data;
        public string? Message;
        public IList<string>? Errors;
        public Exception? Exception;
        public bool? Success;

        public APIResponse(int status, object? data = null, string? message = null, Exception? exception = null, IList<string>? errors = null, bool? success = null)
        {
            this.StatusCode = status;
            this.Data = data;
            this.Message = message;
            this.Exception = exception;
            this.Errors = errors;
            this.Success = success;
        }
    }
}

