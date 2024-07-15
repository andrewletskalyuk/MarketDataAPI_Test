using MarketDataAPI.AutoMapper;
using MarketDataAPI.Data;
using MarketDataAPI.Services;
using MarketDataAPI.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Market Data API", Version = "v1" });
});

// Access to dbcontext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add SignalR
builder.Services.AddSignalR();

// Register services
builder.Services.AddScoped<IMarketAssetService, MarketAssetService>();
builder.Services.AddScoped<IHistoricalPriceService, HistoricalPriceService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<WebSocketClientService>();
builder.Services.AddHostedService<WebSocketBackgroundService>();

// Register HttpClient
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Market Data API V1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<MarketDataHub>("/marketdatahub");

app.Run();