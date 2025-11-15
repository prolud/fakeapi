using application.UseCases;
using domain.Interfaces.Repositories;
using infra;
using infra.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

/// DI
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<GenerateJwtUseCase>();

builder.Services.AddDbContext<AppDbContext>();
/// DI

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();

app.UseHttpsRedirection();
app.Run();