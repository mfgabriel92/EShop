using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Services;

public class DiscountService(DiscountContext dbContext) : DiscountProtoService.DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await GetCoupon(dbContext, request.Id);
        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        var coupon = GetCoupon(request.Coupon);

        dbContext.Coupons.Add(coupon);
        await dbContext.SaveChangesAsync();

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        var coupon = GetCoupon(request.Coupon);

        dbContext.Coupons.Update(coupon);
        await dbContext.SaveChangesAsync();

        return coupon.Adapt<CouponModel>();
    }

    public override async Task<DeleteCouponResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        var coupon = await GetCoupon(dbContext, request.Id);

        dbContext.Coupons.Remove(coupon!);
        await dbContext.SaveChangesAsync();

        return new DeleteCouponResponse { Success = true };
    }

    private static async Task<Coupon?> GetCoupon(DiscountContext dbContext, int id)
    {
        var coupon = await dbContext
            .Coupons
            .FirstOrDefaultAsync(x => x.Id == id);

        if (coupon is null)
        {
            coupon = new Coupon { Id = 0, ProductName = "N/A", Description = "N/A", Amount = 0 };
        }

        return coupon;
    }

    private static Coupon GetCoupon(CouponModel request)
    {
        var coupon = request.Adapt<Coupon>();

        if (coupon is null)
        {
            throw new RpcException(
                new Status(StatusCode.Unavailable, "Coupon does not exist")
            );
        }

        return coupon;
    }
}
