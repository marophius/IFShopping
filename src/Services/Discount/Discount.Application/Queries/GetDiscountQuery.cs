using Discount.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Queries
{
    public record GetDiscountQuery(string ProductName) : IRequest<Coupon>
    {
    }
}
