using Inlämning1Tomaso.Data;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Repos;
using Inlämning1Tomaso.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// --------------------------------------------
// Add controllers
// --------------------------------------------
builder.Services.AddControllers();

builder.Services.AddDbContext<TomasoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// --------------------------------------------
// Dependency Injection – Repositories & Services
// --------------------------------------------

// Category
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Dish
builder.Services.AddScoped<IDishRepo, DishRepo>();
builder.Services.AddScoped<IDishService, DishService>();

// Ingredient
builder.Services.AddScoped<IIngredientRepo, IngredientRepo>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

// Order
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IOrderService, OrderService>();

// User
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

// --------------------------------------------
// Swagger configuration
// --------------------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Tomasos Pizzeria API",
        Version = "v1",
        Description = "Web API för Tomasos beställningssystem.",
    });
});

var app = builder.Build();

// --------------------------------------------
// Middleware pipeline
// --------------------------------------------
if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tomasos Pizzeria API v1");
        c.RoutePrefix = string.Empty; // Swagger UI direkt på root
    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
