using External_API_Calling.DAL.Repositories.Implementations;
using External_API_Calling.DAL.Repositories.Interfaces;
using External_API_Calling.Services.Implementations;
using External_API_Calling.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json"
    , optional: true
    , reloadOnChange: true);

// Add services to the container.
builder.Services.AddScoped<IGettingDataRepo, GettingDataRepo>();
builder.Services.AddTransient<IDataManipulatorService,DataManipulatorService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
