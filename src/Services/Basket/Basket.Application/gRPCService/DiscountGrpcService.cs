using Discount.Grpc.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.gRPCService
{
    public class DiscountGrpcService 
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountService)
        {
            _discountService = discountService;
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = productName };

            return await _discountService.GetDiscountAsync(discountRequest);
        }
    }
}
