using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Commands
{
    public record UpdateOrderCommand(int Id,
                                     string UserName, 
                                     decimal TotalPrice,
                                     string FirstName,
                                     string LastName,
                                     string EmailAddress,
                                     string AddressLine,
                                     string Country,
                                     string State,
                                     string ZipCode,
                                     string CardName,
                                     string CardNumber,
                                     string Expiration,
                                     string CVV,
                                     int PaymentMethod) : IRequest<Unit>
    {
    }
}
