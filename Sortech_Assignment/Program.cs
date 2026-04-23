
using Microsoft.OpenApi;
using Sortech_Assignment.Application.DependencyInjection;
using Sortech_Assignment.Infrastructure.DependencyInjection;
using Sortech_Assignment.Infrastructure.ExternalCalling.IPgeoLocation;

namespace Sortech_Assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddInfrastructureDI();
            builder.Services.AddApplicationDI();
            builder.Services.AddHttpClient();   
            builder.Services.Configure<IPgeoLocationSetting>(builder.Configuration.GetSection(IPgeoLocationSetting.Name));
            
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
