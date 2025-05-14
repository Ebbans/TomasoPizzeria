using Inlämning1Tomaso.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning1Tomaso.Data
{
    public class TomasoDbContext : DbContext
    {
        public TomasoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<DishIngredient> DishIngredients { get; set; }
        public DbSet<OrderDish> OrderDish { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 📌 DishIngredient: Composite key och relationer
            modelBuilder.Entity<DishIngredient>()
                .HasKey(di => new { di.DishID, di.IngredientID });

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishID);

            modelBuilder.Entity<DishIngredient>()
                .HasOne(di => di.Ingredient)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientID);

            // 📌 OrderDish: Composite key och relationer
            modelBuilder.Entity<OrderDish>()
                .HasKey(od => new { od.OrderID, od.DishID });

            modelBuilder.Entity<OrderDish>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDishes)
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<OrderDish>()
                .HasOne(od => od.Dish)
                .WithMany(d => d.OrderDishes)
                .HasForeignKey(od => od.DishID);
        }
    }
}
