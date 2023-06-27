using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using BlogAPI.Errors;

namespace BlogAPI.Middleware
{
    public class ExceptionMiddleware
    {
         private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        private readonly IHostEnvironment _env;
        
        /**
        * RequestDelegate next : a function that process a Http Request and return a Task
          it's the only paramettre required
        */
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;    
        }

        /**
        * we are telling the framework that this a middleware so we have to name this methode 
          InvokeAsync because that what it uses to know what is the next move.
          the pipeline goes from middleware to another middleware by calling the next (byOrder).

          HttpContext gives the Http request goes threw the middleware 
        */
        public async Task InvokeAsync(HttpContext context)
        {
            try{
                await _next(context);
            }
            catch(Exception ex){

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, ex.Message, "Internal Server Error");

                var options = new JsonSerializerOptions{PropertyNamingPolicy = JsonNamingPolicy.CamelCase}; 

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);

            }

        }
    }
}