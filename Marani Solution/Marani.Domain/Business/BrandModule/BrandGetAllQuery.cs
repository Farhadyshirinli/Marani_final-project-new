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

namespace Marani.Domain.Business.BrandModule
{
    public class BrandGetAllQuery : IRequest<List<Brand>>
    {
        public class BrandGetAllQueryHandler : IRequestHandler<BrandGetAllQuery, List<Brand>>
        {
            private readonly MaraniDbContext db;

            public BrandGetAllQueryHandler(MaraniDbContext db)
            {
                this.db = db;
            }


            public async Task<List<Brand>> Handle(BrandGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Brands.Where(m => m.DeletedDate == null)
               .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
