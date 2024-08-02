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
            modelBuilder.Entity<Review>().HasKey(u => u.Id);
            modelBuilder.Entity<Coupon>().HasKey(u => u.Id);

            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = 1, Name = "Hamleys", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1712913605Frame_1597879841.webp" },
                new Brand { Id = 2, Name = "Lego", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1712915096Frame_1597879850.webp" },
                new Brand { Id = 3, Name = "Mattel", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1712914915Frame_1597879840.webp" },
                new Brand { Id = 4, Name = "Rabitat", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1717745558raa.webp" },
                new Brand { Id = 5, Name = "EMotorad", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1718860419Shop_by_brand.webp" },
                new Brand { Id = 6, Name = "Barbie", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1712914616Frame_1597879855.webp" }
            );

            modelBuilder.Entity<Category>().HasData(
              new Category { Id = 2, Name = "SportsAndOutdoor", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135308802.webp" },
            new Category { Id = 3, Name = "ToysAndGames", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135309171.webp" },
            new Category { Id = 4, Name = "RideonsAndCycles", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135308153.webp" },
            new Category { Id = 5, Name = "SchoolAndTravel", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/171353085110.webp" },
            new Category { Id = 6, Name = "FashionAndAccessiores", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135305644.webp" },
            new Category { Id = 7, Name = "Books", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135305376.webp" },
            new Category { Id = 8, Name = "Gadgets", ImageUrl = "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135306877.webp" }
             );

            modelBuilder.Entity<Toy>().HasData(
               new Toy
               {
                   Id = 6,
                   Name = "Playnxt Yellow Pro Set Cricket Set Outdoor Sports for Boys age 8Y+",
                   Description = "Elevate your cricket game with the PLAYNXT Yellow Pro Set Cricket Set. This complete premium kit includes a professional bat, stumps, base, bails, and a tennis ball, providing an authentic cricket experience for boys aged 8 years and above. The bat features a rubber grip and curved blade for powerful strokes, while the realistic stumps with durable base and bails add to the immersive gameplay. This cricket set not only enhances motor skills and hand-eye coordination but also fosters decision-making and teamwork. Made from high-quality HDPE plastic, it ensures safety for kids. With its trendy sports bag, this set is easily portable for outdoor play. Take your cricket skills to new heights with PLAYNXT!",
                   CategoryId = 2,
                   BrandId = 2,
                   AgeRange = "7-9years",
                   Price = "1700",
                   Discount = "10",
                   ArrivalDate = DateTime.Now,
                   ImageUrl = "https://cdn.pixelspray.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-product/491185768/300/491185768-1.webp",
                   Quantity = 2
               },
                new Toy
                {
                    Id = 7,
                    Name = "Barbie New Dream House",
                    Description = "When young imaginations move into the Barbie Dreamhouse, they turn this amazing dollhouse into a dream home! More than 3 feet tall and 4 feet wide, the Barbie Dreamhouse has so many amazing features - three stories, eight rooms that include a carport (car not included) and a home office, a working elevator that fits four dolls, a pool that has a slide descending from the story above, five pieces of transforming furniture, lights, sounds and more than 60 additional accessories, including an adorable puppy, that can all be used to decorate, set the scene and play out so many stories. Plug-and-play design helps keep pieces in place as small hands move around (and make clean up easy for adult hands!). Decorations and furniture for indoor and outdoor settings inspire play from all angles, and the transformations provide two-in-one fun while encouraging flexible action - the couch turns into bunk beds, the coffee table flips for a bed sized for Chelsea doll (sold separately), the fireplace becomes a home office, the refrigerator turns into an outdoor food stand and the oven houses a barbecue in back. Lights and sounds add even more delightful touches - the oven lights up and the timer ticks, the stovetop sizzles with the frying pan and whistles with the tea kettle and the toilet makes a flushing sound. Young decorators will have so much fun moving accessories around the house as they explore their personal style and tell all kinds of stories, from daytime to nighttime, indoor to outdoor, Barbie home alone or with a house full of friends and family (dolls sold separately). Pool parties, friend sleepovers, sister bonding, backyard BBQs, birthday, holidays and every day there are endless stories to tell and limitless ways to explore living in the Barbie Dreamhouse because with Barbie, anything is possible. Includes Barbie Dreamhouse and 70 accessories that include furniture, household items and a puppy; dolls, fashions and car not included. Colors and decorations may vary.",
                    CategoryId = 3,
                    BrandId = 5,
                    AgeRange = "3-5years",
                    Price = "22999",
                    Discount = "10",
                    ArrivalDate = DateTime.Now,
                    ImageUrl = "https://hmadmin.hamleys.in/product/491232286/300/491636216-2.jpg",
                    Quantity = 6
                },
                new Toy
                {
                    Id = 8,
                    Name = "Hamleys Star Cross PVC Football for Kids",
                    Description = "Football Size - 5, Durable, Leather Ball, Perfect gift for your loved ones",
                    CategoryId = 2,
                    BrandId = 2,
                    AgeRange = "5-7years",
                    Price = "899",
                    Discount = "10",
                    ArrivalDate = DateTime.Now,
                    ImageUrl = "https://cdn.pixelspray.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-product/491489879/300/491489879-1.webp",
                    Quantity = 1
                },
                new Toy
                {
                    Id = 9,
                    Name = "EMotorad Lile Kidz Freedom is Here Kick E-Scooter Blue",
                    Description = "The Lile Kidz Freedom is Here Kick E Scooter is an exceptional electric scooter tailored for riders aged 10 years and above. Packed with innovative features and boasting a sleek design, this e scooter offers a convenient and eco-friendly mode of transportation. With a 7.5Ah lithium-ion battery, it provides a range of up to 20 km on a single charge. The scooter features an LCD display, LED headlamp, thumb throttle, and 8.5 tires. Its foldable, lightweight, and boasts IPX4 water resistance, making it a versatile choice for urban commuting and leisure rides. This scooter combines style, performance, and convenience. With a robust battery, advanced features like an LCD display and LED headlamp, and the versatility of water resistance and foldability, its an excellent choice for urban commuting, recreational rides, and more. Riders of all ages will appreciate its user-friendly design and eco-conscious operation.",
                    CategoryId = 4,
                    BrandId = 3,
                    AgeRange = "12-14years",
                    Price = "34999",
                    Discount = "14",
                    ArrivalDate = DateTime.Now,
                    ImageUrl = "https://hmadmin.hamleys.in/product/494348364/300/LilE%20product%20DP%20blue.jpg",
                    Quantity = 5
                },
                new Toy
                {
                    Id = 10,
                    Name = "Speed Up Leisure Cricket Set Kids Toye",
                    Description = "Compact and easy to carry, it is an ideal mate for your everyday leisure cricket and vacations",
                    CategoryId = 2,
                    BrandId = 5,
                    AgeRange = "8-10years",
                    Price = "1499",
                    Discount = "0",
                    ArrivalDate = DateTime.Now,
                    ImageUrl = "https://cdn.pixelspray.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-product/491960045/300/491960045-1.jpeg",
                    Quantity = 2
                }

             );

            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, CouponCode = "WELCOME100", DiscountPrice = "100" }
            );

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

        }

    }
}
 