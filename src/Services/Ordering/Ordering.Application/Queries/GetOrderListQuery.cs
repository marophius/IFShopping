using MediatR;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Queries
{
    public record GetOrderListQuery(string UserName) : IRequest<List<OrderResponse>>
    {
    }
}
