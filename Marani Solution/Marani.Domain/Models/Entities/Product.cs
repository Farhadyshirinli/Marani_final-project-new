using Marani.Domain.AppCode.Infrastructure;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marani.Domain.Models.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductImages> Images { get; set; }
        public virtual ICollection<ProductCatalogItem> ProductCatalog { get; set; }
    }
}
