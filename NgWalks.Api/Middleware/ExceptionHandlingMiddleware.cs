using System.Net;

namespace NgWalks.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> logger;
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                //log exception
                var errorId = Guid.NewGuid();
                logger.LogError(ex, $"{errorId} : ex.Message");

                //Return a custom error message.
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Sorry something went wrong! We are resolving it"
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
