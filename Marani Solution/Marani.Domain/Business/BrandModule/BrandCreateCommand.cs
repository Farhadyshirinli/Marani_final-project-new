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

    public class BrandCreateCommand : IRequest<Brand>
    {
        public string Name { get; set; }

        public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, Brand>
        {
            private readonly MaraniDbContext db;

            public BrandCreateCommandHandler(MaraniDbContext db)
            {
                this.db = db;
            }
            public async Task<Brand> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
            {
                var model = new Brand();
                model.Name = request.Name;
                await db.Brands.AddAsync(model, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return model;
            }
        }
    }


}
