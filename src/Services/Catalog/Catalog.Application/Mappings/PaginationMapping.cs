using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappings
{
    public static class PaginationMapping
    {
        public static Pagination<ProductResponse> ToPaginationProductResponse(this Pagination<Product> page)
        {
            return new Pagination<ProductResponse>(page.PageIndex, page.PageSize, (int)page.Count, page.Data.Select(d => d.ToProductResponse()).ToList().AsReadOnly());
        }
    }
}
