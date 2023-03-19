using KingTech.SolarEdgeClient;
using KingTech.SolarEdgeClient.Extensions;
using KingTech.SolarEdgeClient.MessageBroker;
using KingTech.SolarEdgeClient.Modbus;
using KingTech.SolarEdgeClient.Modbus.Devices;
using KingTech.SolarEdgeClient.Modbus.Settings;
using KingTech.SolarEdgeClient.Prometheus;
using KingTech.SolarEdgeClient.Services;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

// Add endpoints to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<PrometheusMetricPublisher>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add settings to the container.
builder.Configure<SolarEdgeModbusSettings>(new SolarEdgeModbusSettings());
builder.Configure<GeneralSettings>(new GeneralSettings());

// Register SolarEdge modbus services.
builder.Services.AddSingleton<ISolarEdgeModbusClient, SolarEdgeModbusClient>();
builder.Services.AddSingleton<ISolarEdgeService, SolarEdgeService>();
builder.Services.AddSingleton<IMessageBroker<IDevice>, GenericMessageBroker<IDevice>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Prometheus metrics
//Make sure this call is made before the call to UseEndPoints.
app.UseMetricServer();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//Set start and stop events.
var lifeTime = app.Services.GetService<IHostApplicationLifetime>();
lifeTime?.ApplicationStarted.Register(() => {
    app.Services.GetService<ISolarEdgeService>()?.Start();
    app.Services.GetService<PrometheusMetricPublisher>()?.Start();
});
lifeTime?.ApplicationStopping.Register(() => {
    app.Services.GetService<ISolarEdgeService>()?.Stop();
    app.Services.GetService<PrometheusMetricPublisher>()?.Stop();
});

//Start web application.
app.Run();
