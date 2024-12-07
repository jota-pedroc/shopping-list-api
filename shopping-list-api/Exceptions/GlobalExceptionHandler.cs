using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using shopping_list_api.Contracts;

namespace shopping_list_api.Exceptions;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, exception.Message);

        var errorResponse = new ErrorResponse
        {
            Message = exception.Message,
            Title = exception.GetType().Name,
        };

        switch (exception)
        {
            case BadHttpRequestException:
                errorResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case NoItemFoundException:
            case ItemDoesNotExistException:
                errorResponse.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                errorResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }
        
        httpContext.Response.StatusCode = errorResponse.StatusCode;
        
        await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);
        return true;
    }
}