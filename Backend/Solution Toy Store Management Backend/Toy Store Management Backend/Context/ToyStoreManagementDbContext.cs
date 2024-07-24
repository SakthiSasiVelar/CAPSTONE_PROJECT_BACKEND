using Microsoft.EntityFrameworkCore;
using Toy_Store_Management_Backend.Models;

namespace Toy_Store_Management_Backend.Context
{
    public class ToyStoreManagementDbContext : DbContext
    {
        public ToyStoreManagementDbContext(DbContextOptions dbContextOptions) : base (dbContextOptions) { }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAuthDetails> UserAuthDetails { get; set; }

        public DbSet<Toy> Toys { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<DiscountAndCharges> DiscountAndCharges { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Coupon> Coupons { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u =>  u.Id);
            modelBuilder.Entity<UserAuthDetails>().HasKey(uad => uad.Id);
            modelBuilder.Entity<Toy>().HasKey(u => u.Id);
            modelBuilder.Entity<Brand>().HasKey(u => u.Id);
            modelBuilder.Entity<CartItem>().HasKey(u => u.Id);
            modelBuilder.Entity<Category>().HasKey(u => u.Id);
            modelBuilder.Entity<DiscountAndCharges>().HasKey(u => u.Id);
            modelBuilder.Entity<Order>().HasKey(u => u.Id);
            modelBuilder.Entity<OrderItem>().HasKey(u => u.Id);
            modelBuilder.Entity<Payment>().HasKey(u => u.Id);
            modelBuilder.Entity<Review>().HasKey(u => u.Id);
            modelBuilder.Entity<Coupon>().HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<UserAuthDetails>()
                .HasIndex(uad => uad.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .ValueGeneratedNever();

            modelBuilder.Entity<UserAuthDetails>()
               .Property(uad => uad.Email)
               .ValueGeneratedNever();

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ct => ct.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(ct => ct.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

              modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserAuthDetails>()
                .HasOne(uad => uad.User)
                .WithOne(u => u.UserAuthDetails)
                .HasForeignKey<UserAuthDetails>(uad => uad.UserId)
                .HasPrincipalKey<User>(u => u.Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Toy)
                .WithMany(t => t.Reviews)
                .HasForeignKey(r => r.ToyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Toy)
                .WithMany(t => t.Orders)
                .HasForeignKey(oi => oi.ToyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Toy)
                .WithMany(t => t.Carts)
                .HasForeignKey(ci => ci.ToyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Toy>()
                .HasOne(t => t.Brand)
                .WithMany(b => b.Toys)
                .HasForeignKey(t =>  t.BrandId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Toy>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Toys)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.SuccessFulPayment)
                .WithOne(p => p.SuccessFulOrder)
                .HasForeignKey<Order>(o => o.SuccessFulPaymentId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
 