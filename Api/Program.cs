using System.Text;
using Business;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repo;

namespace Api;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        //builder.Services.AddSwaggerGen();

        #region JWT Authentication
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:5117",
        ValidAudience = "https://localhost:5117",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
    };
});
builder.Services.AddAuthorization();

#endregion
        builder.Services.AddScoped<IBusinessNewUser, BusinessNewUser>();
        builder.Services.AddScoped<IBusinessLoginUser, BusinessLoginUser>();
        builder.Services.AddScoped<IBusinessFileClaim, BusinessFileClaim>();
        builder.Services.AddScoped<IBusinessGetUserClaim, BusinessGetUserClaim>();

        builder.Services.AddScoped<IRepoNewUser, RepoNewUser>();
        builder.Services.AddScoped<IRepoLoginUser, RepoLoginUser>();
        builder.Services.AddScoped<IRepoFileClaim, RepoFileClaim>();
        builder.Services.AddScoped<IRepoGetUserClaim, RepoGetUserClaim>();

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
    }
}
