using Basket.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Queries
{
    public record GetBasketByUserNameQuery(string Username) : IRequest<ShoppingCartResponse>
    {
    }
}
