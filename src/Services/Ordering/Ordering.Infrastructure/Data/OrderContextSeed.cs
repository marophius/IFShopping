using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation($"Ordering Database: {typeof(OrderContext).Name} seeded.");
            }
        }

        private static IEnumerable<Order> GetOrders()
        {
            return new List<Order>
        {
            new()
            {
                UserName = "IcaroFelix",
                FirstName = "Icaro",
                LastName = "Felix",
                EmailAddress = "ifeme08@gmail.com",
                AddressLine = "Salvador",
                Country = "Brazil",
                TotalPrice = 750,
                State = "BA",
                ZipCode = "40270220",

                CardName = "Master",
                CardNumber = "1234567890123456",
                CreatedBy = "Icaro",
                Expiration = "12/25",
                Cvv = "123",
                PaymentMethod = 1,
                LastModifiedBy = "Icaro",
                LastModifiedDate = new DateTime(),
            }
        };
        }
    }
}
