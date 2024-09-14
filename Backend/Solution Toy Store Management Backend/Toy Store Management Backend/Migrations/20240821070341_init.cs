using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Toy_Store_Management_Backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountAndCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceDiscount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountAndCharges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    AgeRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Toys_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Toys_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    DeliveryCharge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuccessFulPaymentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAuthDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PasswordHashKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAuthDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ToyId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ToyId = table.Column<int>(type: "int", nullable: false),
                    Ratings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ToyId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusActionDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Toys_ToyId",
                        column: x => x.ToyId,
                        principalTable: "Toys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1712913605Frame_1597879841.webp", "Hamleys" },
                    { 2, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1712915096Frame_1597879850.webp", "Lego" },
                    { 3, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1712914915Frame_1597879840.webp", "Mattel" },
                    { 4, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1717745558raa.webp", "Rabitat" },
                    { 5, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1718860419Shop_by_brand.webp", "EMotorad" },
                    { 6, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/1712914616Frame_1597879855.webp", "Barbie" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 2, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135308802.webp", "SportsAndOutdoor" },
                    { 3, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135309171.webp", "ToysAndGames" },
                    { 4, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135308153.webp", "RideonsAndCycles" },
                    { 5, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/171353085110.webp", "SchoolAndTravel" },
                    { 6, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135305644.webp", "FashionAndAccessiores" },
                    { 7, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135305376.webp", "Books" },
                    { 8, "https://cdn.pixelbin.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-banner/17135306877.webp", "Gadgets" }
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "CouponCode", "DiscountPrice" },
                values: new object[] { 1, "WELCOME100", "100" });

            migrationBuilder.InsertData(
                table: "Toys",
                columns: new[] { "Id", "AgeRange", "ArrivalDate", "BrandId", "CategoryId", "Description", "Discount", "ImageUrl", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 6, "8-10years", new DateTime(2024, 8, 21, 12, 33, 41, 181, DateTimeKind.Local).AddTicks(3653), 2, 2, "Elevate your cricket game with the PLAYNXT Yellow Pro Set Cricket Set. This complete premium kit includes a professional bat, stumps, base, bails, and a tennis ball, providing an authentic cricket experience for boys aged 8 years and above. The bat features a rubber grip and curved blade for powerful strokes, while the realistic stumps with durable base and bails add to the immersive gameplay. This cricket set not only enhances motor skills and hand-eye coordination but also fosters decision-making and teamwork. Made from high-quality HDPE plastic, it ensures safety for kids. With its trendy sports bag, this set is easily portable for outdoor play. Take your cricket skills to new heights with PLAYNXT!", "10", "https://cdn.pixelspray.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-product/491185768/300/491185768-1.webp", "Playnxt Yellow Pro Set Cricket Set Outdoor Sports for Boys", "1700", 2 },
                    { 7, "3-5years", new DateTime(2024, 8, 21, 12, 33, 41, 181, DateTimeKind.Local).AddTicks(3672), 6, 3, "When young imaginations move into the Barbie Dreamhouse, they turn this amazing dollhouse into a dream home! More than 3 feet tall and 4 feet wide, the Barbie Dreamhouse has so many amazing features - three stories, eight rooms that include a carport (car not included) and a home office, a working elevator that fits four dolls, a pool that has a slide descending from the story above, five pieces of transforming furniture, lights, sounds and more than 60 additional accessories, including an adorable puppy, that can all be used to decorate, set the scene and play out so many stories. Plug-and-play design helps keep pieces in place as small hands move around (and make clean up easy for adult hands!). Decorations and furniture for indoor and outdoor settings inspire play from all angles, and the transformations provide two-in-one fun while encouraging flexible action - the couch turns into bunk beds, the coffee table flips for a bed sized for Chelsea doll (sold separately), the fireplace becomes a home office, the refrigerator turns into an outdoor food stand and the oven houses a barbecue in back. Lights and sounds add even more delightful touches - the oven lights up and the timer ticks, the stovetop sizzles with the frying pan and whistles with the tea kettle and the toilet makes a flushing sound. Young decorators will have so much fun moving accessories around the house as they explore their personal style and tell all kinds of stories, from daytime to nighttime, indoor to outdoor, Barbie home alone or with a house full of friends and family (dolls sold separately). Pool parties, friend sleepovers, sister bonding, backyard BBQs, birthday, holidays and every day there are endless stories to tell and limitless ways to explore living in the Barbie Dreamhouse because with Barbie, anything is possible. Includes Barbie Dreamhouse and 70 accessories that include furniture, household items and a puppy; dolls, fashions and car not included. Colors and decorations may vary.", "10", "https://hmadmin.hamleys.in/product/491232286/300/491636216-2.jpg", "Barbie New Dream House", "22999", 6 },
                    { 8, "5-7years", new DateTime(2024, 8, 21, 12, 33, 41, 181, DateTimeKind.Local).AddTicks(3674), 1, 2, "Football Size - 5, Durable, Leather Ball, Perfect gift for your loved ones", "10", "https://cdn.pixelspray.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-product/491489879/300/491489879-1.webp", "Hamleys Star Cross PVC Football for Kids", "899", 1 },
                    { 9, "12-14years", new DateTime(2024, 8, 21, 12, 33, 41, 181, DateTimeKind.Local).AddTicks(3677), 5, 4, "The Lile Kidz Freedom is Here Kick E Scooter is an exceptional electric scooter tailored for riders aged 10 years and above. Packed with innovative features and boasting a sleek design, this e scooter offers a convenient and eco-friendly mode of transportation. With a 7.5Ah lithium-ion battery, it provides a range of up to 20 km on a single charge. The scooter features an LCD display, LED headlamp, thumb throttle, and 8.5 tires. Its foldable, lightweight, and boasts IPX4 water resistance, making it a versatile choice for urban commuting and leisure rides. This scooter combines style, performance, and convenience. With a robust battery, advanced features like an LCD display and LED headlamp, and the versatility of water resistance and foldability, its an excellent choice for urban commuting, recreational rides, and more. Riders of all ages will appreciate its user-friendly design and eco-conscious operation.", "14", "https://hmadmin.hamleys.in/product/494348364/300/LilE%20product%20DP%20blue.jpg", "EMotorad Lile Kidz Freedom is Here Kick E-Scooter Blue", "34999", 5 },
                    { 10, "8-10years", new DateTime(2024, 8, 21, 12, 33, 41, 181, DateTimeKind.Local).AddTicks(3679), 2, 2, "Compact and easy to carry, it is an ideal mate for your everyday leisure cricket and vacations", "0", "https://cdn.pixelspray.io/v2/black-bread-289bfa/HrdP6X/original/hamleys-product/491960045/300/491960045-1.jpeg", "Speed Up Leisure Cricket Set Kids Toye", "1499", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ToyId",
                table: "CartItems",
                column: "ToyId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ToyId",
                table: "OrderItems",
                column: "ToyId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ToyId",
                table: "Reviews",
                column: "ToyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Toys_BrandId",
                table: "Toys",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Toys_CategoryId",
                table: "Toys",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthDetails_Email",
                table: "UserAuthDetails",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthDetails_UserId",
                table: "UserAuthDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "DiscountAndCharges");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "UserAuthDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Toys");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
