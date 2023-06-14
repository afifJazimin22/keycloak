using Keycloak.AuthServices.Authentication;
using KeycloakMicroservice.Services;
using Microsoft.AspNetCore.Authentication.Certificate;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;
var host = builder.Host;
// services.AddKeycloakAuthentication

var services = builder.Services;
// services.AddKeycloakAuthentication(configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAngularOrigins",
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:5040/api/users")
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                      });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IConnectService, ConnectService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAngularOrigins");
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
