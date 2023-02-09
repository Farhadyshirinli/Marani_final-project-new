using Marani.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace Marani.Domain.Models.Entities
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }
    }
}
