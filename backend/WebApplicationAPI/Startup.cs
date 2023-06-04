using AutoMapper;
using BookShop.Application.Repositories;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Persistance.Repositories;
using BookShop.Mappings;
using BookShop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace WebApplicationAPI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddCors();


            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile(new BookMappingProfile());
                m.AddProfile(new OrderMappingProfile());
            });

            // Global exception filter
            // services.AddControllers(options => options.Filters.Add(typeof(ApiExceptionFilter)));
            services.AddControllers();
            services.AddSingleton(mapperConfig.CreateMapper());
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IOrderService, OrderService>();




            services.AddDbContext<ProjectContext>
            (opt => opt.UseSqlServer(Configuration.GetConnectionString("DbConnection") ??
                                     throw new InvalidOperationException()));

            services.AddControllers()
                .AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StarDance.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
       

    }

}
