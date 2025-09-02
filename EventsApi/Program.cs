using EventsApi.Services;
using EventsApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var eventsApiConfig = builder.Configuration.GetSection("EventsApi");

builder.Services.AddScoped<IEventsService, CivicPlusEventsService>();
builder.Services.AddScoped<IAuthService, CivicPlusAuthService>();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();