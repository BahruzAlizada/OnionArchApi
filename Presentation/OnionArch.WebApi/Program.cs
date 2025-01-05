using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using OnionArch.Application.Features.Commands.Product.CreateProduct;
using OnionArch.Application.Registration;
using OnionArch.Infrastructure.Registration;
using OnionArch.Domain.Identity;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Registration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices();

builder.Services.AddIdentity<AppUser, AppRole>(Identityoptions =>
{
    Identityoptions.User.RequireUniqueEmail = true;
    Identityoptions.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
    Identityoptions.Password.RequiredLength = 8;
    Identityoptions.Password.RequireNonAlphanumeric = false;
    Identityoptions.Lockout.AllowedForNewUsers = true;
    Identityoptions.Lockout.MaxFailedAccessAttempts = 5;
    Identityoptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin",options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, // Yaradýlacaq token d?y?rl?rini hansý saytlarýn istifad? ed?c?yi d?y?rdir
            ValidateIssuer = true, // Yaradýlacaq token d?y?rini kimin daðýttýdýðný ifad? edil??ck d?y?rdir
            ValidateLifetime = true, //Yaradýlacaq token d?y?rini vaxtýný kontrol ed?c?k
            ValidateIssuerSigningKey = true, //Yaradýlacaq token d?y?rinin proqrama aid bir d?y?r olduðunu ifad? ed?n suciry key verisinin doðrulanmasýdýr

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires!= null ? expires> DateTime.UtcNow : false
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
