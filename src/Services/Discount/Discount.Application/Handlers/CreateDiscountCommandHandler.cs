using Discount.Application.Commands;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Handlers
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, Coupon>
    {
        private readonly IDiscountRepository _discountRepository;

        public CreateDiscountCommandHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<Coupon> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var coupon = new Coupon
            {
                ProductName = request.ProductName,
                Description = request.Description,
                Amount = request.Amount,
            };

            await _discountRepository.CreateDiscount(coupon);

            return coupon;
        }
    }
}
