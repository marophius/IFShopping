using Basket.Application.Responses;
using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Mappers
{
    public static class ShoppingCartMapper
    {
        public static ShoppingCartResponse ToShoppingCartResponse(this ShoppingCart cart)
        {
            if (cart.Items is null)
                return new ShoppingCartResponse
                {
                    UserName = cart.UserName
                };
            return new ShoppingCartResponse
            {
                UserName = cart.UserName,
                Items = cart.Items.Select(i => i.ToShoppingCartItemResponse()).ToList()
            };
        }
    }
}
