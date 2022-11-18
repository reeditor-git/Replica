using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Profiles;
using Replica.Application.Repositories.Hookahs;
using Replica.Application.Repositories.Orders;
using Replica.Persistence;

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

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            builder.Services.AddScoped<ComponentCategoryRepository>();
            builder.Services.AddScoped<HookahComponentRepository>();
            builder.Services.AddScoped<HookahRepository>();

            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<GameZoneRepository>();
            builder.Services.AddScoped<OrderRepository>();
            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<SubcategoryRepository>();
            builder.Services.AddScoped<TableRepository>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.AddSwaggerGen();

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

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}