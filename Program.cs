using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using Microsoft.EntityFrameworkCore;
using backend.Entities;
using backend.Repositories;
using backend.Repositories.Interfaces;

using backend.Services;
using backend.Services.Interfaces;
// using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddSwaggerGen(options =>
// {
//     options.AddSecurityDefinition("Bearer",
//         new OpenApiSecurityScheme
//         {
//             Name = "Authorization",
//             Type = SecuritySchemeType.Http,
//             Scheme = "bearer",
//             BearerFormat = "JWT",
//             In = ParameterLocation.Header,
//             Description = "Enter JWT token"
//         });

//     options.AddSecurityRequirement(
//         new OpenApiSecurityRequirement
//         {
//             {
//                 new OpenApiSecurityScheme
//                 {
//                     Reference =
//                         new OpenApiReference
//                         {
//                             Type = ReferenceType.SecurityScheme,
//                             Id = "Bearer"
//                         }
//                 },
//                 Array.Empty<string>()
//             }
//         });
// });




builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AlumniDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["JWT:Issuer"],

        ValidAudience = builder.Configuration["JWT:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!))
    };
});

builder.Services.AddAuthorization();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");


app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();



app.Run();


