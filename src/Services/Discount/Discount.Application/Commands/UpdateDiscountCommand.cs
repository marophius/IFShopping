using Discount.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{
    public record UpdateDiscountCommand(int Id, string ProductName, string Description, int Amount) : IRequest<Coupon>
    {
    }
}
