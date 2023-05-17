using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using Repository.Interfaces;
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var settings = provider.GetRequiredService<IConfiguration>();
// Add services to the container.
builder.Services.AddCors(op => {
    var frontURL = settings.GetValue<string>("Front_End");

    op.AddDefaultPolicy(builder => {
        builder.WithOrigins(frontURL!).AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericServices<>), typeof(GenericServices<>));

builder.Services.AddDbContext<StudentsContext>(op => op.UseNpgsql("name=ConnectionStrings:DefaultConnection"));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
