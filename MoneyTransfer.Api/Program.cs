using Application;
using Helper;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureDatabase(builder.Configuration);
builder.Services.AddRepository();
builder.Services.AddService();
builder.Services.ConfigureOption(builder.Configuration);
builder.Services.AddSerilogger(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddMapperConfig();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.AddProviderHttpClient(builder.Configuration, "Jibit", "JibitConfig");
builder.Services.AddProviderHttpClient(builder.Configuration, "Hangfire", "HangfireConfig");
builder.Services.AddReqResLogging();
builder.Services.AddApiVersion();
builder.Services.AddOptions();
builder.Services.AddHttpContextAccessor();
builder.Services.AddExceptionMiddleware();
builder.Services.AddSsoConfig(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpLogging();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.Run();