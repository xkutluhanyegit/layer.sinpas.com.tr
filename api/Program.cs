using application.interfaces;
using application.services;
using infrastracture.backgroundservice.interfaces;
using infrastracture.externalservices.meyerapi.interfaces;
using infrastracture.externalservices.meyerapi.services;
using infrastracture.persistance.repositories.dapper.employee;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddTransient<HttpClient>();

builder.Services.AddScoped<IMeyerGetTokenService,MeyerGetTokenService>();
builder.Services.AddScoped<IEmployeeService,EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();

builder.Services.AddScoped<IMeyerSetSicilService,MeyerSetSicilService>();

builder.Services.AddHostedService<MeyerBackgroundService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

