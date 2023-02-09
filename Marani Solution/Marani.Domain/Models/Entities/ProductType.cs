using Marani.Domain.AppCode.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marani.Domain.Models.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }
    }
}
