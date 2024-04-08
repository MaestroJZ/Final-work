using Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;
using WebAPI.Configs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
ModuleConfig.ConfigureModule(builder.Services);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapControllers();

app.Run();

