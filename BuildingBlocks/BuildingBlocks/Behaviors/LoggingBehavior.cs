using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        logger.LogInformation(
            "[START] Handle request={Request} - Response={Response} - ResponseData={ResponseData}",
            typeof(TRequest).Name,
            typeof(TResponse).Name,
            request
        );

        var timer = new Stopwatch();
        var response = await next();

        timer.Stop();

        var seconds = timer.Elapsed.Seconds;
        if (seconds > 3)
        {
            logger.LogWarning(
                "[PERFORMANCE] The requesst {Request} took {TimeTaken} seconds",
                typeof(TRequest).Name,
                seconds
            );
        }

        return response;
    }
}