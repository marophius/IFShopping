using Discount.Application.Commands;
using Discount.Application.Queries;
using Discount.Grpc.Protos;
using Discount.GRPC.Mapper;
using Grpc.Core;
using MediatR;

namespace Discount.GRPC.Services
{
    public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DiscountService> _logger;

        public DiscountService(IMediator mediator, ILogger<DiscountService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var query = new GetDiscountQuery(request.ProductName);
            var result = await _mediator.Send(query);

            if(result is null)
            {
                throw new RpcException(new Status(StatusCode.NotFound,
                $"Discount with the product name = {request.ProductName} not found"));
            }

            _logger.LogInformation($"Discount is retrieved for the Product Name: {request.ProductName} and Amount : {result.Amount}");
            return result.ToCouponModel();
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var cmd = new CreateDiscountCommand(request.Coupon.ProductName, request.Coupon.Description, request.Coupon.Amount);
            var result = await _mediator.Send(cmd);
            _logger.LogInformation($"Discount is successfully created for the Product Name: {result.ProductName}");
            return result.ToCouponModel();
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var cmd = new UpdateDiscountCommand(request.Coupon.Id, request.Coupon.ProductName, request.Coupon.Description, request.Coupon.Amount);
            var result = await _mediator.Send(cmd);
            _logger.LogInformation($"Discount is successfully updated Product Name: {result.ProductName}");
            return result.ToCouponModel();
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var cmd = new DeleteDiscountCommand(request.ProductName);
            var deleted = await _mediator.Send(cmd);
            var response = new DeleteDiscountResponse
            {
                Success = deleted
            };
            return response;
        }
    }
}
