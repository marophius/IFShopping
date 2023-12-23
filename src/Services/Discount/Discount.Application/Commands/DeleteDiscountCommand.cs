using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Commands
{
    public record DeleteDiscountCommand(string ProductName) : IRequest<bool>
    {
    }
}
