
using Domain.Contracts;
using E_Commerce.Web1.Factories;
using E_Commerce.Web1.Middelwares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;
using Persistence.Repositories;
using Services;
using ServicesAbstractions;
using Shared.ErrorModels;

namespace E_Commerce.Web1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddWebApplicationServices();


            var app = builder.Build();
            // await   InitializeDbAsync(app);
            await app.InitializeDataBaseAsync();
            //app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            app.UseCustomExceptionMiddleware();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            // app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        
    }


}


// GetAllProducts => product
// GetById => product/{id}
// GetBrands => product/brands
// GetTypes => product/types