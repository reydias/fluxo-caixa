using FluxoCaixa.Api;
using FluxoCaixa.Data;
using FluxoCaixa.Business;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Configura��es do servi�o
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<LancamentoRepository>();
builder.Services.AddScoped<ILancamentoBusiness, LancamentoBusiness>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<LancamentoQuery>()
    .AddMutationType<LancamentoMutation>()
    .AddType<LancamentoType>()
    .AddType<ConsolidadoDiarioType>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "FluxoCaixa API v1");
    c.RoutePrefix = string.Empty; // Para abrir o Swagger na raiz (opcional)
});

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
*/
