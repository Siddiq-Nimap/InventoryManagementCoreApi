using Microsoft.EntityFrameworkCore;

namespace ProductManagementWebAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatagoryList>().HasKey(l => new { l.PId, l.CId });
            
        }
        public string cs = "data source = DESKTOP-TFBH7SV;Initial Catalog = DataBaseAPI; Integrated security = true;TrustServerCertificate=True;";
        public DbSet<Products> Products { get; set; }
        public DbSet<Catagories> Catagories { get; set; }
        public DbSet<CatagoryList> CatagoryLists { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
