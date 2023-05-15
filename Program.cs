using LoginApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Agregar la configuracion del Context relacionado con la BD de SQLserver
builder.Services.AddDbContext<ApplicatioDbContext>(
    // Aqui llamamos a la cadena de conexion
    opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"))
);

// Configuracion del AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
// Production
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
