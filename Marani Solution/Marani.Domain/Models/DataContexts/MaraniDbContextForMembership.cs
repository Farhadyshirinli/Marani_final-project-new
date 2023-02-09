using Marani.Domain.Models.Entities;
using Marani.Domain.Models.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marani.Domain.Models.DataContexts
{
    public partial class MaraniDbContext
    {


        public DbSet<MaraniRole> Roles { get; set; }
        public DbSet<MaraniRoleClaim> RoleClaims { get; set; }
        public DbSet<MaraniUser> Users { get; set; }
        public DbSet<MaraniUserClaim> UserClaim { get; set; }
        public DbSet<MaraniUserLogin> UserLogins { get; set; }
        public DbSet<MaraniUserRole> UserRoles { get; set; }
        public DbSet<MaraniUserToken> UserTokens{ get; set; }






    }
}
