var builder = WebApplication.CreateBuilder(args);

// Добавляем базовые сервисы
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// === AutoMapper ===
builder.Services.AddAutoMapper(typeof(gearzone.businesslogic.Mappings.MappingProfile));

// === Репозитории ===
builder.Services.AddScoped<gearzone.dataaccess.Repositories.IProductRepository,
                           gearzone.dataaccess.Repositories.ProductRepository>();

// === Сервисы ===
builder.Services.AddScoped<gearzone.businesslogic.Services.IProductService,
                           gearzone.businesslogic.Services.ProductService>();

var app = builder.Build();

// Настройка Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "GearZone API");
        options.RoutePrefix = string.Empty;   // Swagger будет главной страницей
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();