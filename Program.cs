﻿using Inlämning1Tomaso.Data;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Repos;
using Inlämning1Tomaso.Data.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Azure.Identity;

// --------------------------------------------
// Konfiguration & Key Vault
// --------------------------------------------
var builder = WebApplication.CreateBuilder(args);

var keyVaultName = "tomaso-Key";  // Ditt Key Vault namn
var keyVaultUri = new Uri($"https://{keyVaultName}.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(keyVaultUri, new DefaultAzureCredential());

// --------------------------------------------
// Add controllers & DbContext
// --------------------------------------------

// Läs connection string direkt från Key Vault
var connectionString = builder.Configuration["Tomaso:Connstring"]
    ?? throw new InvalidOperationException("Missing Tomaso:Connstring");

// Registrera DbContext med connection string från Key Vault
builder.Services.AddDbContext<TomasoDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

// --------------------------------------------
// Dependency Injection – Repositories & Services
// --------------------------------------------
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IDishRepo, DishRepo>();
builder.Services.AddScoped<IDishService, DishService>();

builder.Services.AddScoped<IIngredientRepo, IngredientRepo>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();

// --------------------------------------------
// Läs JWT-inställningar från Key Vault
// --------------------------------------------
var issuer = builder.Configuration["JWT:Issuer"]
    ?? throw new InvalidOperationException("Missing JWT:Issuer");
var audience = builder.Configuration["JWT:Audience"]
    ?? throw new InvalidOperationException("Missing JWT:Audience");
var key = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]
    ?? throw new InvalidOperationException("Missing JWT:Key"));

// --------------------------------------------
// JWT Authentication
// --------------------------------------------
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = true,
        ValidAudience = audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true
    };

    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine($"JWT error: {context.Exception.Message}");
            return Task.CompletedTask;
        }
    };
});

// --------------------------------------------
// Swagger Configuration
// --------------------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tomaso API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Skriv in 'Bearer {token}'",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
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
            new string[] {}
        }
    };

    c.AddSecurityRequirement(securityRequirement);
});

// --------------------------------------------
// Build & Run
// --------------------------------------------
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tomasos Pizzeria API");
        c.RoutePrefix = string.Empty;
        c.DocumentTitle = "Tomaso API Dokumentation";
    });
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
