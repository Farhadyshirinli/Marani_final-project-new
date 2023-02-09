using Marani.Domain.AppCode.Infrastructure;
using Marani.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marani.Domain.Models.Entites
{
   public class BlogPostTagItem : BaseEntity
    {
        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
