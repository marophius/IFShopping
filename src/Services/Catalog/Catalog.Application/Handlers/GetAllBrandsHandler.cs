﻿using Catalog.Application.Mappings;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponse>>
    {
        private readonly IBrandRepository _brandRepository;
        public GetAllBrandsHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<IList<BrandResponse>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brandList = await _brandRepository.GetAllBrands();

            var brandResponseList = brandList.Select(b => b.ToBrandResponse()).ToList();

            return brandResponseList;
        }
    }
}
