using application.UseCases;
using domain.Interfaces.Repositories;
using domain.Interfaces.Services;
using infra;
using infra.Repositories;
using infra.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

/// DI
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<LoginUseCase>();

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddDbContext<AppDbContext>()
/// DI

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapControllers();

app.UseHttpsRedirection();
app.Run();