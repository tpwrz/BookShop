using AutoMapper;
using BookShop.Application.Repositories;
using BookShop.Infrastructure.Persistance.Repositories;
using BookShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext>(optionBuilder =>
{
    optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new BookMappingProfile());
});

// Global exception filter
// services.AddControllers(options => options.Filters.Add(typeof(ApiExceptionFilter)));
builder.Services.AddControllers();
builder.Services.AddSingleton(mapperConfig.CreateMapper());
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// Configure the HTTP request pipeline.



 void ConfigureServices(IServiceCollection services)
{
    services.AddCors();

    var mapperConfig = new MapperConfiguration(m =>
    {
        m.AddProfile(new BookMappingProfile());
    });

    // Global exception filter
    // services.AddControllers(options => options.Filters.Add(typeof(ApiExceptionFilter)));
    builder.Services.AddControllers();
    builder.Services.AddSingleton(mapperConfig.CreateMapper());
    builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
    builder.Services.AddScoped<IBookService, BookService>();



    services.AddRouting(options =>
    {
        options.ConstraintMap.Add("integer", typeof(int));
    });

    services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "StarDance_API",
            Version = "v1"
        });
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement {
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

}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



    app.UseCors(options => options
        .WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
    );

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
