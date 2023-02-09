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
    public class MaraniUserRoleEntityTypeConfiguration : IEntityTypeConfiguration<MaraniUserRole>
    {
        public void Configure(EntityTypeBuilder<MaraniUserRole> builder)
        {
            builder.ToTable("UserRoles", "Membership");
        }
    }
}
