using Microsoft.EntityFrameworkCore;
using User.Repository;
using User.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UserInfoDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLdb")));

builder.Services.AddScoped<UserInfoService>();
builder.Services.AddScoped<UserInfoRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
