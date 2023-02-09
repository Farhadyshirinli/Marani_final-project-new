using Marani.Domain.AppCode.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marani.Domain.Models.Entities
{
    public class ProductRegion : BaseEntity
    {
        public string Name { get; set; }
        public string SmallName { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }
    }
}
