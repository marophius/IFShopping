using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetProductsByBrandQuery : IRequest<IList<ProductResponse>>
    {
        public string Brandname { get; set; }

        public GetProductsByBrandQuery(string brandname)
        {
            Brandname = brandname;
        }
    }
}
