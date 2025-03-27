using Hireplicity.CodeChallenge.Api.Data;
using Hireplicity.CodeChallenge.Api.Services.Concretes;
using Hireplicity.CodeChallenge.Api.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.EnableAnnotations());

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

//Repositories
builder.Services.AddScoped<IHireplicityRepositories, HireplicityRepositories>();

//Connection string
builder.Services.AddDbContext<HirepilicityDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("HirepilicityDbConnection")));

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
