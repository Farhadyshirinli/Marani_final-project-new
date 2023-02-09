using Marani.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marani.Domain.Models.DataContexts.Configurations
{
    public class MaraniUserLoginEntityTypeConfiguration : IEntityTypeConfiguration<MaraniUserLogin>
    {
        public void Configure(EntityTypeBuilder<MaraniUserLogin> builder)
        {
            builder.ToTable("UserLogins", "Membership");
        }
    }
}
