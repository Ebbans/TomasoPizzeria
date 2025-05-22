using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning1Tomaso.Data
{
    public class TomasoDbContext : DbContext
    {
        public TomasoDbContext(DbContextOptions<TomasoDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<OrderDish> OrderDishes { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OrderDish: sammansatt nyckel
            modelBuilder.Entity<OrderDish>()
                .HasKey(od => new { od.OrderID, od.DishID });

            // Decimal precision
            modelBuilder.Entity<Dish>()
                .Property(d => d.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDish>()
                .Property(od => od.Price)
                .HasColumnType("decimal(18,2)");

            // ✅ Dish - Ingredient (1 till många)
            modelBuilder.Entity<Ingredient>()
                .HasOne(i => i.Dish)
                .WithMany(d => d.Ingredients)
                .HasForeignKey(i => i.DishID);
        }


    }
}
