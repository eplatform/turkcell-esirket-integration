using Serilog;
using TurkcellEsirketIntegration.Services;
using TurkcellEsirketIntegration.Settings;

var builder = WebApplication.CreateBuilder(args);

// Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog();
builder.WebHost.ConfigureKestrel(serverOptions =>
           {
               serverOptions.Listen(System.Net.IPAddress.Loopback, 5008);
           });
// Config
builder.Services.Configure<IntegrationAuthSettings>(
    builder.Configuration.GetSection("Integration:Auth"));

// Services
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<IAuthService, AuthService>();

builder.Services.AddHttpClient<IEfaturaService, EfaturaService>(client =>
{
    var config = builder.Configuration
           .GetSection("Integration:Services:Efatura")
           .Get<ServiceEndpointSettings>();
    client.BaseAddress = new Uri(config!.BaseUrl);
});

builder.Services.AddHttpClient<IEirsaliyeService, EirsaliyeService>(client =>
{
    var config = builder.Configuration
        .GetSection("Integration:Services:Eirsaliye")
        .Get<ServiceEndpointSettings>();

    client.BaseAddress = new Uri(config!.BaseUrl);
});

// builder.Services.AddScoped<IEfaturaService, EfaturaService>();
// builder.Services.AddScoped<IEirsaliyeService, EirsaliyeService>();

// Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();