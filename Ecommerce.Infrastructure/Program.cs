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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new() { Title = "Ecommerce", Version = "v1" });
        options.SchemaFilter<EnumSchemaFilter>();
    });


// Add database context into app
builder.Services.AddDbContext<ApplicationDbContext>(options =>

    options
    .EnableSensitiveDataLogging()
    .LogTo(Console.WriteLine, LogLevel.Information)
    .AddInterceptors(new TimeStampInterceptor())
    .UseNpgsql(builder.Configuration.GetConnectionString("localhost"))
    .UseSnakeCaseNamingConvention());


// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductColorRepository, ProductColorRepository>();
builder.Services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
//builder.Services.AddScoped<ExceptionHandlerMiddleware>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAuthManagement, AuthManagement>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserManagement, UserManagement>();

// Add authentication configuration
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
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

app.MapControllers();


app.Run();
