using CRUD.infraestructura;
using CRUD.interfaz;
using CRUD.repositorio.alumno;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias
builder.Services.AddScoped<ConexionAdonet>();
builder.Services.AddScoped<IAlumnoRepository, AlumnoAdonetRepository>();
builder.Services.AddScoped<AlumnoQuery>();
builder.Services.AddScoped<AlumnoCommand>();

// Configurar CORS para permitir comunicación desde cualquier cliente
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();