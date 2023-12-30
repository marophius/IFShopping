using Ordering.Application.Responses;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mappers
{
    public static class OrderOrderResponseMapper
    {
        public static OrderResponse ToOrderResponse(this Order order)
        {
            return new OrderResponse
            {
                Id = order.Id,
                UserName = order.UserName,
                FirstName = order.FirstName,
                LastName = order.LastName,
                EmailAddress = order.EmailAddress,
                AddressLine = order.AddressLine,
                Country = order.Country,
                State = order.State,
                ZipCode = order.ZipCode,
                CardName = order.CardName,
                CardNumber = order.CardNumber,
                Expiration = order.Expiration,
                CVV = order.Cvv,
                TotalPrice = order.TotalPrice,
                PaymentMethod = order.PaymentMethod
            };
        }
    }
}
