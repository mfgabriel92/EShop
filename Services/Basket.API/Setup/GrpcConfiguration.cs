using Discount.gRPC;

namespace Basket.API.Setup;

public static class GrpcConfiguration
{
    public static WebApplicationBuilder AddGrpcConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(options =>
        {
            options.Address = new Uri(builder.Configuration["GrpcSettings:DiscountUrl"]!);
        }).ConfigurePrimaryHttpMessageHandler(() =>
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };

            return handler;
        });

        return builder;
    }
}
