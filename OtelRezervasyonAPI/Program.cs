using Microsoft.EntityFrameworkCore;
using OtelRezervasyonAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = "Server=tcp:4458.database.windows.net,1433;Initial Catalog=hotel_database;Persist Security Info=False;User ID=efe;Password=cenk_2486;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

// DbContext'i yapýlandýr
builder.Services.AddDbContext<OtelRezervasyonContext>(options =>
    options.UseSqlServer(connectionString, sqlServerOptions =>
        sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null)));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
