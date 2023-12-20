using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands
{
    public record CreateShoppingCartCommand(string Username, List<ShoppingCartItem> Items) : IRequest<ShoppingCartResponse>
    {
    }
}
