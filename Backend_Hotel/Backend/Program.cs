using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a la contenedor.
builder.Services.AddControllers();

// Configuración de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar servicios personalizados
builder.Services.AddScoped<HabitacionServices>(); // Servicio de habitación
builder.Services.AddScoped<ServicioServices>(); // Servicio de servicio
builder.Services.AddScoped<HuespedServices>(); // Servicio del huésped
builder.Services.AddScoped<ReservaServices>(); // Servicio de reserva
builder.Services.AddScoped<HabitacionReservaServices>(); // Servicio de habitación_reserva
builder.Services.AddScoped<ConexionServices>(); // Registro del servicio de conexión

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Permite solo el origen de tu aplicación React
              .AllowAnyMethod() // Permite todos los métodos HTTP
              .AllowAnyHeader(); // Permite todos los encabezados
    });
});

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Aplicar la política de CORS antes de cualquier otro middleware
app.UseCors("ReactPolicy");

// Habilitar redirección HTTPS y autorización
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

// Ejecutar la aplicación
app.Run();
