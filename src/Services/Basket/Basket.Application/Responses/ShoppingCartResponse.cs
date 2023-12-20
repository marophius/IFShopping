using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Responses
{
    public class ShoppingCartResponse
    {
        public string UserName { get; set; }
        public List<ShoppingCartItemResponse> Items { get; set; } = new List<ShoppingCartItemResponse>();

        public ShoppingCartResponse()
        {

        }

        public ShoppingCartResponse(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;

                totalPrice = Items.Select(item =>
                {
                    var price = item.Price * item.Quantity;
                    return price;
                }).Sum();

                return totalPrice;
            }
        }
    }
}
