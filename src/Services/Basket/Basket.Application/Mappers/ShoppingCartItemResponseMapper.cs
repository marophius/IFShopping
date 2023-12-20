using Basket.Application.Responses;
using Basket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Mappers
{
    public static class ShoppingCartItemResponseMapper
    {

        public static ShoppingCartItemResponse ToShoppingCartItemResponse(this ShoppingCartItem cart)
        {
            return new ShoppingCartItemResponse
            {
                Quantity = cart.Quantity,
                ImageFile = cart.ImageFile,
                Price = cart.Price,
                ProductId = cart.ProductId,
                ProductName = cart.ProductName
            };
        }
    }
}
