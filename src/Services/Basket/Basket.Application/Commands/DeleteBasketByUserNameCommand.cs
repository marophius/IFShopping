﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Commands
{
    public record DeleteBasketByUserNameCommand(string Username) : IRequest<Unit>
    {
    }
}
