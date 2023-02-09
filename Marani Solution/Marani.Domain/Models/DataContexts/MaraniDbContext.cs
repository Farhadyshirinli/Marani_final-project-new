using Marani.Domain.Models.DataContexts.Configurations;
using Marani.Domain.Models.Entites;
using Marani.Domain.Models.Entities;
using Marani.Domain.Models.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marani.Domain.Models.DataContexts
{
    public partial class MaraniDbContext : IdentityDbContext<MaraniUser, MaraniRole, int, MaraniUserClaim, MaraniUserRole, MaraniUserLogin, MaraniRoleClaim, MaraniUserToken>
    {
        public MaraniDbContext(DbContextOptions options)
            : base(options)
        {

        }



        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactPost> ContactPosts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductsImages { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductRegion> ProductRegions { get; set; }
        public DbSet<ProductQuality> ProductQuality { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductCatalogItem> ProductCatalog { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogPostComment> BlogPostComments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BlogPostTagItem> BlogPostTagCloud { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MaraniDbContext).Assembly);
        }


    }
}
