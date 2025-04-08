using Application.DTO;
using Application.Interfaces.Services;
using Infrastructure;
// using Infrastructure.Data;
using Infrastructure.Middlewares;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Information)
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .Enrich.WithProcessId()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq("http://seq:5341")
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

var app = builder.Build();

// Middleware de Serilog
app.UseSerilogRequestLogging();
// Middleware de gestion d'erreurs
app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// DataSeeder
// using (var scope = app.Services.CreateScope())
// {
//    await DataSeeder.SeedAsync(scope.ServiceProvider);
// }

app.MapGet("/dossier/{id:guid}", async (Guid id, IDossierService dossierService, ILogger<Program> logger) =>
{
    logger.LogInformation("Starting Get By Id with {Id}", id);
    var dossierDto = await dossierService.GetByIdAsync(id);
    return dossierDto is { } ? Results.Ok(dossierDto) : Results.NotFound();
});

app.MapPost("/addDossier", async (CreateDossierDto dto, IDossierService dossierService) =>
{
    var dossierDto = await dossierService.CreateAsync(new CreateDossierDto(
                    dto.UniteProprietaire,
                    dto.NatureDossier,
                    dto.TypeDossier,
                    dto.DateDesConstatations,
                    dto.DateDeClotureDuPv,
                    dto.DateEnregistrement
                ));
    return Results.Created($"/dossier/{dossierDto.Id}", dossierDto);
});

app.MapGet("/dossiers", async (IDossierService dossierService) =>
{
    var dossiers = await dossierService.GetAllAsync();
    return Results.Ok(dossiers);
});

app.Run();
