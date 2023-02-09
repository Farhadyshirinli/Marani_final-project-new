using Marani.Domain.Models.DataContexts;
using Marani.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Marani.Domain.Business.BlogPostModule
{
    public class BlogPostGetAllQuery : IRequest<List<BlogPost>>
    {
        public class BlogPostGetAllQueryHandler : IRequestHandler<BlogPostGetAllQuery, List<BlogPost>>
        {
            private readonly MaraniDbContext db;

            public BlogPostGetAllQueryHandler(MaraniDbContext db)
            {
                this.db = db;
            }
            public async Task<List<BlogPost>> Handle(BlogPostGetAllQuery request, CancellationToken cancellationToken)
            {
                var posts = await db.BlogPosts
                    .Where(bp => bp.DeletedDate == null && bp.PublishedDate != null)
                    .ToListAsync(cancellationToken);

                return posts;



            }
        }
    }
}
