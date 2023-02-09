using Marani.Domain.AppCode.Infrastructure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Marani.Domain.Models.Entities
{
    public class ProductQuality : BaseEntity
    {
        public decimal Volume { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }
    }
}
