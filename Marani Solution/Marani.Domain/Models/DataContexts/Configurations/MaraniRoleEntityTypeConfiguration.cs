using Marani.Domain.Models.Entities.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marani.Domain.Models.DataContexts.Configurations
{
    public class MaraniRoleEntityTypeConfiguration : IEntityTypeConfiguration<MaraniRole>
    {
        public void Configure(EntityTypeBuilder<MaraniRole> builder)
        {
            builder.ToTable("Roles", "Membership");
        }
    }
}
