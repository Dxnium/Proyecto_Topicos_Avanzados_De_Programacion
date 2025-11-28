using GestionDePersonas.BL;
using GestionDePersonas.DA;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DBContexto>(options =>
//    options.UseInMemoryDatabase("Proyecto_TopicosDB"));
builder.Services.AddDbContext<DBContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<GestionDePersonas.BL.IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<GestionDePersonas.BL.IAdministradorDePersonas, AdministradorDePersonas>();
builder.Services.AddScoped<GestionDePersonas.BL.IAdministradorDeVehiculos, AdministradorDeVehiculos>();
builder.Services.AddScoped<GestionDePersonas.BL.IVehiculoRepository, VehiculoRepository>();

builder.Services.AddScoped<GestionDePersonas.BL.IAdministradorDeUsuarios, AdministradorDeUsuarios>();
builder.Services.AddScoped<GestionDePersonas.BL.IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
