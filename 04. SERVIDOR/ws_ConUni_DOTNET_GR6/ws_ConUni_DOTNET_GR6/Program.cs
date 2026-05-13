    using ec.edu.monster.servicio;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();

    // Registrar servicio consolidado
    builder.Services.AddScoped<IConversionService, ConversionService>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddOpenApi();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
