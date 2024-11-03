using Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios a la contenedor.
builder.Services.AddControllers();

// Configuraci�n de Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agregar servicios personalizados
builder.Services.AddScoped<HabitacionServices>(); // Servicio de habitaci�n
builder.Services.AddScoped<ServicioServices>(); // Servicio de servicio
builder.Services.AddScoped<HuespedServices>(); // Servicio del hu�sped
builder.Services.AddScoped<ReservaServices>(); // Servicio de reserva
builder.Services.AddScoped<HabitacionReservaServices>(); // Servicio de habitaci�n_reserva
builder.Services.AddScoped<ConexionServices>(); // Registro del servicio de conexi�n

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Permite solo el origen de tu aplicaci�n React
              .AllowAnyMethod() // Permite todos los m�todos HTTP
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

// Aplicar la pol�tica de CORS antes de cualquier otro middleware
app.UseCors("ReactPolicy");

// Habilitar redirecci�n HTTPS y autorizaci�n
app.UseHttpsRedirection();
app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

// Ejecutar la aplicaci�n
app.Run();
