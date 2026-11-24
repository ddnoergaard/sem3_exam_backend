using api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;   // NY
using Microsoft.IdentityModel.Tokens;                  // NY
using Microsoft.OpenApi;
using System.Text;                                     // NY

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Repo (Singleton, fordi data ligger i en liste)
builder.Services.AddSingleton<ParkingSpotRepository>(new ParkingSpotRepository(includeData: true));
builder.Services.AddSingleton<AdminRepository>();

// 1. Definer et policy navn
var myAllowSpecificOrigins = "AllowAll";

// 2. Tilføj CORS service og configure policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins, policy =>
    {
        policy.AllowAnyOrigin() // policy.WithOrigins("http://localhost:<Port>") // godkend en specifik origin
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// NY: JWT-opsætning
string jwtKey = builder.Configuration["Jwt:Key"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Tilføj swagger (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Indtast din JWT token"
    });
    opt.AddSecurityRequirement(doc => new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecuritySchemeReference("Bearer", doc),
            new List<string>()
        }
    });
});

var app = builder.Build();

// Slå Swagger til
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(myAllowSpecificOrigins); // Opsæt Cors

app.UseAuthentication();   // NY: hvem er du? Skal stå FØR UseAuthorization

app.UseAuthorization();    // må du det?

app.MapControllers();

app.Run();