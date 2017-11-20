using System.Data.Entity;

namespace ARC.DAC
{
    public class Database : DbContext
    {
        public DbSet<Models.Contact> Contact { get; set; }
        public DbSet<Models.ARCImage> ARCImage { get; set; }
        public DbSet<Models.ImageType> ImageType { get; set; }
        public DbSet<Models.Review> Review { get; set; }
        public DbSet<Models.SiteLanguage> SiteLanguage { get; set; }

        public Database() : base("ARC Connection")
        {
            System.Data.Entity.Database.SetInitializer<Database>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.ARCImage>().ToTable("dbo.images");
            modelBuilder.Entity<Models.ImageType>().ToTable("dbo.imageTypes");
            modelBuilder.Entity<Models.Contact>().ToTable("dbo.contacts");
            modelBuilder.Entity<Models.Review>().ToTable("dbo.reviews");
            modelBuilder.Entity<Models.SiteLanguage>().ToTable("dbo.siteText");

        }
    }
}