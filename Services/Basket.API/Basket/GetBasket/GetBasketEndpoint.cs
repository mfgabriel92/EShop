namespace Basket.API.Basket.GetBasket;

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{username}", async (string username, ISender sender) =>
            {
                var result = await sender.Send(new GetBasketQuery(username));
                var response = result.Adapt<GetBasketResponse>();

                return Results.Ok(response);
            })
            .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}