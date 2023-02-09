using Marani.Domain.AppCode.Infrastructure;
using System.Collections;
using System.Collections.Generic;

namespace Marani.Domain.Models.Entities
{
    public class ProductImages: BaseEntity
    {
        public string Name { get; set; }
        public bool isMain { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
