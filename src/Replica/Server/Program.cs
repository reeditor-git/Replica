using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Replica.Application.Interfaces;
using Replica.Application.Repository.Hookahs;
using Replica.Persistence;
using System.Reflection;

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

            builder.Services.AddAutoMapper(config =>
                {
                   // config.AddProfile(new AssemblyMappingProfile(typeof(IReplicaDbContext).Assembly));
                });

            builder.Services.AddScoped<ComponentCategoryRepository>();
            builder.Services.AddScoped<HookahComponentRepository>();
            builder.Services.AddScoped<HookahRepository>();



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