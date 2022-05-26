using System.Reflection;
using Storage.Application;
using Storage.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
services.AddInfrastructure(builder.Configuration.GetConnectionString("MeasurementStorageDatabase"))
    .AddApplication();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddCors(options 
    => options.AddDefaultPolicy(corsPolicyBuilder
        => corsPolicyBuilder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
