using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Replica.Application.Interfaces;
using Replica.Persistence;
using Replica.Server.Infrastructure.Repositories;
using Replica.Server.Middleware;
using Replica.Server.Profiles;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace Replica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("ReplicaDataBase");

            builder.Services.AddDbContext<IReplicaDbContext, ReplicaDbContext>(options =>
            options.UseSqlServer(connectionString,
            x => x.MigrationsAssembly("Replica.Persistence")));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(jwt =>
                {
                    var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Secret"));

                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false, //dev
                        ValidateAudience = false, //dev
                        RequireExpirationTime = false, //dev -refresh token
                        ValidateLifetime = true,

                    };
                });

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            builder.Services.AddScoped<IComponentCategoryRepository, ComponentCategoryRepository>();
            builder.Services.AddScoped<IHookahComponentRepository, HookahComponentRepository>();
            builder.Services.AddScoped<IHookahRepository, HookahRepository>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IGameZoneRepository, GameZoneRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            builder.Services.AddScoped<ITableRepository, TableRepository>();

            builder.Services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();
            builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

            builder.Services.AddControllers();
            //builder.Services.AddRazorPages();

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddRouting(x => x.LowercaseUrls = true);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Replica API v1");
            });

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}