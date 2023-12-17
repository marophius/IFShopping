using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappings
{
    public static class BrandsMapping
    {
        public static BrandResponse ToBrandResponse(this ProductBrand brand )
        {
            return new BrandResponse
            {
                Id = brand.Id,
                Name = brand.Name,
            };
        }

        
    }
}
