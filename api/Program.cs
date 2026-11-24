using api.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Repo (Singleton, fordi data ligger i en liste)
builder.Services.AddSingleton<ParkingSpotRepository>(new ParkingSpotRepository(includeData: true));

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

builder.Services.AddControllers();
builder.Services.AddSingleton<ParkingSpotRepository>();
builder.Services.AddSingleton<AdminRepository>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Tilføj swagger (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseAuthorization();

app.MapControllers();

app.Run();