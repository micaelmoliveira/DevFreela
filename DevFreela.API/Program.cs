using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infra.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* Para consulta
builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseInMemoryDatabase("DevFreela"));
*/

builder.Services.AddDbContext<DevFreelaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DevFreelaCs")));
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
