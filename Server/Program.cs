using Application.Interfaces.Auth;
using Infastructure.Auth;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
var configuration = builder.Configuration;

//services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
//services.Configure<AuthorizationOptions>(configuration.GetSection(nameof(AuthorizationOptions)));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:3000/");
        policy.AllowCredentials();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

services.AddScoped<IPasswordHasher, PasswordHasher>();

services.AddControllers();

// services.AddDbContext<ItesDbContext>(options =>
//     options.UseNpgsql(configuration.GetConnectionString(nameof(ItesDbContext)))
// );

var app = builder.Build();

// using var scope = app.Services.CreateScope();
// await using var dbContext = scope.ServiceProvider.GetRequiredService<ItesDbContext>();
// await dbContext.Database.EnsureCreatedAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCookiePolicy(
    new CookiePolicyOptions
    {
        MinimumSameSitePolicy = SameSiteMode.None,
        HttpOnly = HttpOnlyPolicy.Always,
        Secure = CookieSecurePolicy.Always,
    }
);

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
