using Catalog.Application.Mappings;
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
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponse>>
    {
        private readonly IProductTypeRepository _repository;

        public GetAllTypesHandler(IProductTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<TypeResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typesList = await _repository.GetAllTypes();
            
            return typesList.Select(t => t.ToTypeResponse()).ToList();
        }
    }
}
