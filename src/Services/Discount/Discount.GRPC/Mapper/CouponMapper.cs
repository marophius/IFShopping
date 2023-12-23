using Discount.Core.Entities;
using Discount.Grpc.Protos;

namespace Discount.GRPC.Mapper
{
    public static class CouponMapper
    {
        public static Coupon ToCoupon(this CouponModel coupon)
        {
            return new Coupon
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount
            };
        }

        public static CouponModel ToCouponModel(this Coupon coupon)
        {
            return new CouponModel
            {
                Id = coupon.Id,
                ProductName = coupon.ProductName,
                Description = coupon.Description,
                Amount = coupon.Amount
            };
        }
    }
}
