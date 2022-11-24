using Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using SkillBilAuth.Entities;
using SkillBilAuth.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SkillbillDbContext>();



builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = "276304115303-2g5761uen58ebkdlrk4enkr9j6hbudt1.apps.googleusercontent.com";
    googleOptions.ClientSecret = "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";
    googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
