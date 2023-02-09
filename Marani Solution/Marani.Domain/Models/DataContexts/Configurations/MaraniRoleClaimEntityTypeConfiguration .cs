using Marani.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marani.Domain.Models.DataContexts.Configurations
{
    public class MaraniRoleClaimEntityTypeConfiguration : IEntityTypeConfiguration<MaraniRoleClaim>
    {
        public void Configure(EntityTypeBuilder<MaraniRoleClaim> builder)
        {
            builder.ToTable("RoleClaims", "Membership");
        }
    }
}
