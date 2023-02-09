using Marani.Domain.AppCode.Infrastructure;
using Marani.Domain.Models.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marani.Domain.Models.Entities
{
    public class BlogPostComment : BaseEntity
    {
        public string Text { get; set; }
        public int BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }
        public int ParentId { get; set; }
        public virtual BlogPostComment Parnet { get; set; }
        public virtual ICollection<BlogPostComment> Comments { get; set; }
        public bool Approved { get; set; }
    }
}
