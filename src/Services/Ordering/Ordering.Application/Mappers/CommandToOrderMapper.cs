using EventBus.Messages.Events;
using Ordering.Application.Commands;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Mappers
{
    public static class CommandToOrderMapper
    {
        public static Order ToOrder(this CheckoutOrderCommand command)
        {
            return new Order
            {
                UserName = command.UserName,
                TotalPrice = command.TotalPrice,
                FirstName = command.FirstName,
                LastName = command.LastName,
                EmailAddress = command.EmailAddress,
                AddressLine = command.AddressLine,
                Country = command.Country,
                State = command.State,
                ZipCode = command.ZipCode,
                CardName = command.CardName,
                CardNumber = command.CardNumber,
                Cvv = command.CVV,
                Expiration = command.Expiration,
                PaymentMethod = command.PaymentMethod
            };
        }

        public static BasketCheckoutEvent ToBasketCheckoutEvent(this CheckoutOrderCommand command)
        {
            return new BasketCheckoutEvent
            {
                UserName = command.UserName,
                FirstName = command.FirstName,
                LastName = command.LastName,
                EmailAddress = command.EmailAddress,
                AddressLine = command.AddressLine,
                Country = command.Country,
                State = command.State,
                ZipCode = command.ZipCode,
                CardName = command.CardName,
                CardNumber = command.CardNumber,
                Cvv = command.CVV,
                Expiration = command.Expiration,
                PaymentMethod = command.PaymentMethod
            };
        }

        public static CheckoutOrderCommand ToCheckoutOrderCommand(this BasketCheckoutEvent @event)
        {
            return new CheckoutOrderCommand(@event.UserName,
                (decimal)@event.TotalPrice,
                @event.FirstName,
                @event.LastName,
                @event.EmailAddress,
                @event.AddressLine,
                @event.Country,
                @event.State,
                @event.ZipCode,
                @event.CardName,
                @event.CardNumber,
                @event.Expiration,
                @event.Cvv,
                (int)@event.PaymentMethod
                );
        }

        public static Order ToOrder(this UpdateOrderCommand command)
        {
            return new Order
            {
                Id = command.Id,
                UserName = command.UserName,
                FirstName = command.FirstName,
                LastName = command.LastName,
                EmailAddress = command.EmailAddress,
                AddressLine = command.AddressLine,
                Country = command.Country,
                State = command.State,
                ZipCode = command.ZipCode,
                CardName = command.CardName,
                CardNumber = command.CardNumber,
                Cvv = command.CVV,
                Expiration = command.Expiration,
                PaymentMethod = command.PaymentMethod
            };
        }

    }
}
