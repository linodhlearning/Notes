using Microsoft.EntityFrameworkCore;
using Notes.Api.AutoMapper;
using Notes.Api.Model;
using Notes.Api.Repository;
using Notes.Api.Repository.Entities;
using Notes.Api.Services;
using Notes.Api.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ErrorModel).Assembly));

builder.Services.AddScoped<RepoCoordinator>();
builder.Services.AddScoped<INoteService, NoteService>();

builder.Services.AddAutoMapperSetup();

// Add Dbcontext class   
builder.Services.AddDbContext<NotesDBContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("NotesDbConnection")));
// in memory DB
//builder.Services.AddDbContext<NotesDBContext>(options => options.UseInMemoryDatabase(databaseName: "database_name"));


var app = builder.Build();
 
if (true)// add feature flag 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//migraion
app.DbMigrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
