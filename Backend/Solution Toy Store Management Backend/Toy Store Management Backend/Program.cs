
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Toy_Store_Management_Backend.Context;
using Toy_Store_Management_Backend.Interface;
using Toy_Store_Management_Backend.Models;
using Toy_Store_Management_Backend.Repositories;
using Toy_Store_Management_Backend.Services;

namespace Toy_Store_Management_Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"]))
                   };

               });

            #region DbContext
            builder.Services.AddDbContext<ToyStoreManagementDbContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("sqlDbConnection"))
            );
            #endregion

            #region Repository
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IUserAuthDetailsRepository<int, UserAuthDetails>, UserAuthDetailsRepository>();
            builder.Services.AddScoped<IRepository<int, Brand>, BrandRepository>();
            builder.Services.AddScoped<IRepository<int, Category>, CategoryRepository>();
            builder.Services.AddScoped<IRepository<int, Toy> , ToyRepository> ();
            builder.Services.AddScoped<IRepository<int,CartItem> , CartItemRepository>();
            builder.Services.AddScoped<UserOrderRepository ,  UserOrderRepository>();
            builder.Services.AddScoped<IRepository<int,Order> , OrderRepository>();
            builder.Services.AddScoped<IRepository<int,Coupon>, CouponRepository>();
            builder.Services.AddScoped<IRepository<int,OrderItem> , OrderItemRepository>();
            builder.Services.AddScoped<IRepository<int,Review>, ReviewRepository>();
            builder.Services.AddScoped<ToyReviewRepository ,  ToyReviewRepository>();

            #endregion

            #region Services
            builder.Services.AddScoped<IAuthService, AuthServiceBL>();
            builder.Services.AddScoped<ITokenService , TokenServiceBL>();
            builder.Services.AddScoped<IBrandService, BrandServiceBL>();
            builder.Services.AddScoped<ICategoryService , CategoryServiceBL>();
            builder.Services.AddScoped<IBlobService, BlobService>();
            builder.Services.AddScoped<IToyService, ToyServiceBL>();
            builder.Services.AddScoped<ICartItemService , CartItemServiceBL>();
            builder.Services.AddScoped<ICouponService , CouponServiceBL>();
            builder.Services.AddScoped<IOrderService, OrderServiceBL>();
            builder.Services.AddScoped<IOrderItemService , OrderItemServiceBL>();
            builder.Services.AddScoped<IReviewService, ReviewServiceBL>();
            #endregion

            #region CORS
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("MyCors");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
