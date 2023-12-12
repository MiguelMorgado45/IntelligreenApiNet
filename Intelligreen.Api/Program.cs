using Intelligreen.Aplicacion;
using Intelligreen.Aplicacion.Commands.Plantas;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CrearPlantaCommand).Assembly));
builder.Services.AddDbContext<ApplicationDbContext>(cfg => 
    cfg.UseSqlServer("Server=intelligreendb.database.windows.net,1433;Database=intelligreendb;User Id=rootAdmin;Password=intelligreendb45#;", b => b.MigrationsAssembly("Intelligreen.Api")));
//builder.Services.AddDbContext<ApplicationDbContext>(cfg => cfg.UseSqlite("Data Source=.\\Database\\intelligreen.db", b => b.MigrationsAssembly("Intelligreen.Api")));
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
