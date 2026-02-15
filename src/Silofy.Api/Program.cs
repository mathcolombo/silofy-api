using Silofy.Api.Configs;
using Silofy.Infra.Configs.Contexts;
using Silofy.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSwaggerConfiguration();

const string myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/test-db", async (SilofyDbContext context) =>
{
    try
    {
        var canConnect = await context.Database.CanConnectAsync();
        
        return canConnect 
            ? Results.Ok(new { Message = "Silofy conectado ao Neon com sucesso!" }) 
            : Results.Problem("Não foi possível conectar ao banco.");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Erro de conexão: {ex.Message}");
    }
});

app.Run();

