using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace API.Middleware;

public class ExceptionHandlingMiddleware
{
    public RequestDelegate requestDelegate;
    private readonly ILogger<ExceptionHandlingMiddleware> logger;
    public ExceptionHandlingMiddleware
    (RequestDelegate requestDelegate, ILogger<ExceptionHandlingMiddleware> logger)
    {
        this.requestDelegate = requestDelegate;
        this.logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await requestDelegate(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }
    private Task HandleException(HttpContext context, Exception ex)
    {
        logger.LogError(ex.ToString());

        context.Response.ContentType = "application/json";

        context.Response.StatusCode = ex switch
        {
            ValidationException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError,
        };

        var errorMessageObject = new ExceptionResponse
        {
            Message = ex.Message,
            Status = context.Response.StatusCode
        };

        var errorMessage = JsonConvert.SerializeObject(errorMessageObject);

        return context.Response.WriteAsync(errorMessage);
    }
}

public class ExceptionResponse
{
    [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    [JsonProperty("code")]
    public int Status { get; set; } = (int)HttpStatusCode.InternalServerError;

    [JsonProperty("success")]
    public bool Success { get; set; } = false;
}
