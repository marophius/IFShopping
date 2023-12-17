using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Mappings
{
    public static class ProductMapping
    {
        public static ProductResponse ToProductResponse(this Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Summary = product.Summary,
                Description = product.Description,
                ImageFile = product.ImageFile,
                Price = product.Price,
                Brands = product.Brands.ToBrandResponse(),
                Types = product.Types.ToTypeResponse()
            };
        }

        public static Product CreateProductCommandToProduct(this CreateProductCommand command)
        {
            return new Product
            {
                Name = command.Name,
                Summary = command.Summary,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                Brands = command.Brands,
                Types = command.Types
            };
        }

        public static Product UpdateProductCommandToProduct(this UpdateProductCommand command)
        {
            return new Product
            {
                Id = command.Id,
                Name = command.Name,
                Summary = command.Summary,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
                Brands = command.Brands,
                Types = command.Types
            };
        }
    }
}
