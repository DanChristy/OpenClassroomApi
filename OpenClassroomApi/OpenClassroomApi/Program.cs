using OpenClassroomApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultServices(builder.Configuration);
builder.Services.AddCustomServices();

var app = builder.Build();

app.AddDefaultConfiguration();

app.Run();