using Application.DTO;
using Application.Features.Dossiers.Commands;
using Application.Features.Dossiers.Queries;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Middlewares;
using MediatR;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Information)
    .Enrich.FromLogContext()
    .Enrich.WithEnvironmentName()
    .Enrich.WithMachineName()
    .Enrich.WithProcessId()
    .Enrich.WithHeaderCorrelationId()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.Seq("http://host.docker.internal:5341")
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(Application.AssemblyReference).Assembly));

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

    // DataSeeder
    using (var scope = app.Services.CreateScope())
    {
        await DataSeeder.SeedAsync(scope.ServiceProvider);
    }
}

app.UseHttpsRedirection();


app.MapGet("/dossier/{id:guid}", async (Guid id, IMediator mediator, CancellationToken cancellationToken) =>
{
    var dossierDto = await mediator.Send(new GetDossierByIdQuery(id), cancellationToken);
    return dossierDto is { } ? Results.Ok(dossierDto) : Results.NotFound();
});

app.MapPost("/addDossier", async (CreateDossierDto dto, IMediator mediator, CancellationToken cancellationToken) =>
{
    var createDossier = new CreateDossierCommand(
        dto.UniteProprietaire,
        dto.NatureDossier,
        dto.TypeDossier,
        dto.DateDesConstatations,
        dto.DateDeClotureDuPv,
        dto.DateEnregistrement
    );
    
    var dossierDto = await mediator.Send(createDossier, cancellationToken);

    return Results.Created($"/dossier/{dossierDto.Id}", dossierDto);
});

app.MapGet("/dossiers", async (IMediator mediator, CancellationToken cancellationToken) =>
{
    var dossiers = await mediator.Send(new GetAllDossiersQuery(), cancellationToken);
    return Results.Ok(dossiers);
});

app.Run();
