using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappings
{
    public static class TypeMapping
    {
        public static TypeResponse ToTypeResponse(this ProductType type)
        {
            return new TypeResponse
            {
                Id = type.Id,
                Name = type.Name,

            };
        }
    }
}
