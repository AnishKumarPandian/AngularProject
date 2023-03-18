using core.Interfaces;
using infrastructure;
using infrastructure.Data;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);  

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        

       // var connectionString = Configuration["PostgreSql:ConnectionString"];
        builder.Services.AddDbContext<StoreContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("LoginConnection")));

        IServiceCollection serviceCollection = builder.Services.AddScoped<IProductRepository, ProductRespository>();
        var app = builder.Build();

        using(var scope = app.Services.CreateScope()){

            var db = scope.ServiceProvider.GetRequiredService<StoreContext>();
            db.Database.Migrate();
            await StoreContextSeed.SeedAsync(db);         
        }

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