using BoletoBus_CleanModular.Cliente.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using BoletoBus_CleanModular.Cliente.IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BoletosBusContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BoletosBusContext")));


// Add dependencies
builder.Services.AddClienteDependency();

builder.Services.AddControllers();
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
