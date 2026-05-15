<<<<<<< HEAD
using gearzone.businesslogic.Structure;
using gearzone.dataaccess.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

DbSession.ConnectionStrings =
    builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Р’РІРµРґРёС‚Рµ JWT-С‚РѕРєРµРЅ, РїРѕР»СѓС‡РµРЅРЅС‹Р№ РїРѕ /api/session/auth."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = JwtSettings.Issuer,
            ValidAudience = JwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(JwtSettings.SecretKey)),
            NameClaimType = ClaimTypes.Name,
            RoleClaimType = ClaimTypes.Role
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
=======
using Microsoft.EntityFrameworkCore;
using gearzone.dataaccess.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем базовые сервисы
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// === AutoMapper ===
builder.Services.AddAutoMapper(cfg =>
    cfg.AddProfile<gearzone.businesslogic.Mappings.MappingProfile>());

// === Репозитории ===
builder.Services.AddScoped<gearzone.dataaccess.Repositories.IProductRepository,
                           gearzone.dataaccess.Repositories.ProductRepository>();

// === Сервисы ===
builder.Services.AddScoped<gearzone.businesslogic.Services.IProductService,
                           gearzone.businesslogic.Services.ProductService>();

// === DbContext (EF Core) ===
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Настройка Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "GearZone API");
        options.RoutePrefix = string.Empty; // Swagger будет главной страницей
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
>>>>>>> 8db369f88395dac94fe0ae6c4a5a67b25aebcbc6
