using Basket.Core.Entities;
using EventBus.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Mappers
{
    public static class BasketCheckoutMapper
    {
        public static BasketCheckoutEvent ToBasketCheckoutEvent(this BasketCheckout basket)
        {
            return new BasketCheckoutEvent
            {
                UserName = basket.UserName,
                TotalPrice = basket.TotalPrice,
                FirstName = basket.FirstName,
                LastName = basket.LastName,
                EmailAddress = basket.EmailAddress,
                AddressLine = basket.AddressLine,
                Country = basket.Country,
                State = basket.State,
                ZipCode = basket.ZipCode,
                CardName = basket.CardName,
                CardNumber = basket.CardNumber,
                Expiration = basket.Expiration,
                Cvv = basket.Cvv,
                PaymentMethod = basket.PaymentMethod,
            };
        }
    }
}
