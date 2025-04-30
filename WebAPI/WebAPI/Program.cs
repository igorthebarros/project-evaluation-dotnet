using Database;
using IoC;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Starting WebAPI...");

            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseUrls("http://*:5000");

            // Register Custom IoC
            builder.RegisterDependencies();

            // Infrastructure - ORM Database
            builder.Services.AddDbContext<DefaultContext>(x =>
                x.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Database")
                )
            );

            // Automapper
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<DefaultContext>();
                    context.Database.Migrate();
                }
                
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "web api v1");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

        }
        catch (Exception e)
        {
            Console.WriteLine("ApiGateway terminated unexpectedly");
            Log.Fatal(e, "ApiGateway terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}