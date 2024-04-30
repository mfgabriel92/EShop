using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Services;

public class DiscountService(DiscountContext dbContext) : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

        if (coupon is null)
        {
            coupon = new Coupon { Id = 0, ProductName = "N/A", Description = "N/A", Amount = 0 };
        }

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
        {
            throw new RpcException(
                new Status(StatusCode.InvalidArgument, "Invalid request argument")
            );
        }

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = request.Coupon.Adapt<Coupon>();

        if (coupon is null)
        {
            throw new RpcException(
                new Status(StatusCode.InvalidArgument, "Invalid request argument")
            );
        }

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();

        return coupon.Adapt<CouponModel>();
    }

    public override Task<DeleteCouponResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        return base.DeleteDiscount(request, context);
    }
}
