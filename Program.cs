using BlogAPI;
using BlogAPI.Data;
using BlogAPI.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IRespositiory<Blog>, Respositiory<Blog>>();
builder.Services.AddScoped<IRespositiory<Category>, Respositiory<Category>>();
builder.Services.AddScoped<IRespositiory<User>, Respositiory<User>>();

//authentication & Authorization for login

builder.Services.AddAuthentication().AddBearerToken();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); // use this cores after app.UseAuthorization();

app.MapControllers();

app.Run();
