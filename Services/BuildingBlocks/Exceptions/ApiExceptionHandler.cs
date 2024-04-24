using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingBlocks.Exceptions;

public class ApiExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext ctx, Exception ex, CancellationToken cancellationToken)
    {
        (string Description, int StatusCode) details = ex switch
        {
            ValidationException => (
                ex.Message,
                ctx.Response.StatusCode = StatusCodes.Status400BadRequest
            ),
            NotFoundException => (
                ex.Message,
                ctx.Response.StatusCode = StatusCodes.Status404NotFound
            ),
            _ => (
                ex.Message,
                ctx.Response.StatusCode = StatusCodes.Status500InternalServerError
            )
        };

        var problemDetails = new ProblemDetails
        {
            Detail = details.Description,
            Status = details.StatusCode
        };

        if (ex is ValidationException validationException)
        {
            problemDetails.Extensions.Add("ValidationErrors", validationException.Errors.Select(e => e.ErrorMessage));
        }

        await ctx.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}