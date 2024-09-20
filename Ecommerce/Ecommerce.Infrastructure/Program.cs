using Ecommerce.Domain.src.Interfaces;
using Ecommerce.Infrastructure.src.Repository;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ecommerce.Service.src.AuthService;
using Ecommerce.Infrastructure.src.Repository.Service;
using Ecommerce.Service.src.UserService;
using Newtonsoft.Json.Converters;
using Microsoft.OpenApi.Models;
using Ecommerce.Service.src.ProductColorService;
using Ecommerce.Service.src.ProductSizeService;
using Ecommerce.Service.src.ProductImageService;
using Ecommerce.Service.src.CategoryService;
using Ecommerce.Service.src.OrderService;
using Ecommerce.Service.src.OrderItemService;
using Ecommerce.Service.src.ReviewService;
using Ecommerce.Service.src.PaymentService;
using Ecommerce.Service.src.AddressService;
using Ecommerce.Service.src.ProductService;
using Ecommerce.Service.src.SubCategoryService;
using Ecommerce.Service.src.CartService;
using Ecommerce.Service.src.CartItemService;


var builder = WebApplication.CreateBuilder(args);

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Specify the origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new() { Title = "Ecommerce", Version = "v1" });
        options.SchemaFilter<EnumSchemaFilter>();
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\""
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
    });


// Add database context into app
builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information)
    .AddInterceptors(new TimeStampInterceptor())
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    .UseSnakeCaseNamingConvention());


// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
//builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductColorRepository, ProductColorRepository>();
builder.Services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
//builder.Services.AddScoped<ExceptionHandlerMiddleware>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthManagement, AuthManagement>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserManagement, UserManagement>();
builder.Services.AddScoped<IProductManagement, ProductManagement>();
builder.Services.AddScoped<IProductColorManagement, ProductColorManagement>();
builder.Services.AddScoped<IProductSizeManagement, ProductSizeManagement>();
builder.Services.AddScoped<IProductImageManagement, ProductImageManagement>();
builder.Services.AddScoped<ICategoryManagement, CategoryManagement>();
builder.Services.AddScoped<IOrderManagement, OrderManagement>();
builder.Services.AddScoped<IOrderItemManagement, OrderItemManagement>();
builder.Services.AddScoped<ICartManagement, CartManagement>();
builder.Services.AddScoped<ICartItemManagement, CartItemManagement>();
builder.Services.AddScoped<IReviewManagement, ReviewManagement>();
//builder.Services.AddScoped<IShipmentManagement, ShipmentManagement>();
builder.Services.AddScoped<IPaymentManagement, PaymentManagement>();
builder.Services.AddScoped<IAddressManagement, AddressManagement>();
builder.Services.AddScoped<ISubCategoryManagement, SubCategoryManagement>();

// Add authentication configuration
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }
)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Inject middleware to the application

app.UseHttpsRedirection();
//app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowLocalhost3000");
app.MapControllers();


app.Run();
