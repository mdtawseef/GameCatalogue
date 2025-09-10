using GameCatalog.Api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server Express connection
var cs = builder.Configuration.GetConnectionString("SqlServer");
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// CORS for Angular dev server
const string CorsPolicy = "AngularDev";
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsPolicy, p =>
    p.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod());
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(CorsPolicy);

app.MapControllers();

app.Run();