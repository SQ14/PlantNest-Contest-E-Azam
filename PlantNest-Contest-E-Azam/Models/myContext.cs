using Microsoft.EntityFrameworkCore;

namespace PlantNest_Contest_E_Azam.Models
{
	public class myContext : DbContext
	{
        public myContext(DbContextOptions options) : base (options)
        {
                
        }

		public DbSet<Admin> tbl_admin { get; set; }
		public DbSet<User> tbl_user { get; set; }
		public DbSet<Category> tbl_category { get; set; }
		public DbSet<Plant> tbl_plant { get; set; }
		public DbSet<Accessory> tbl_accessory { get; set; }
		public DbSet<Feedback> tbl_feedback { get; set; }
		public DbSet<Cart> tbl_cart { get; set; }
		public DbSet<Order> tbl_order { get; set; }
		public DbSet<Review> tbl_review { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plant>()
            .HasOne(p => p.categories).WithMany(c => c.plants).HasForeignKey(p => p.category_id);
        }
    }
}
