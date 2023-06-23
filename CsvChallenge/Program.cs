using CsvChallenge.Database;
using CsvChallenge.Repository;
using CsvChallenge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EFDataContext>((options) =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlitedb"));
});

builder.Services.AddSingleton<DapperDataContext>();

builder.Services.AddTransient<ICSVService, CSVService>();
builder.Services.AddTransient<IPersonRepositoryEF, PersonRepositoryEF>();
builder.Services.AddTransient<IImportCsvService, ImportCsvService>();
builder.Services.AddTransient<IPersonRepositoryDapper, PersonRepositoryDapper>();
builder.Services.AddTransient<IPersonService, PersonService>();


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
