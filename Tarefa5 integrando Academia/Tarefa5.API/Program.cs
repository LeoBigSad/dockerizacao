using Microsoft.EntityFrameworkCore;
using Tarefa5.Data.Postgres.Context;
using Tarefa5.Domain.Interfaces.Repository;
using Tarefa5.Data.Repository;
using Tarefa5.Domain.Interfaces.Service;
using Tarefa5.Service.Services;
using Tarefa5.Application.Services;
using Tarefa5.Domain.Interfaces.Rest;
using Tarefa5.Data.Rest.Repository;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<PostgresDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IAcademiaService, AcademiaService>();
builder.Services.AddScoped<IAparelhoService, AparelhoService>();
builder.Services.AddScoped<IAcademiaRepository, AcademiaRepository>();
builder.Services.AddScoped<IAparelhoRepository, AparelhoRepository>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("pessoasApp", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<PostgresDbContext>();
    dbContext.Database.Migrate();
}

app.UseCors("pessoasApp");
app.UseAuthorization();
app.MapControllers();
app.Run();
