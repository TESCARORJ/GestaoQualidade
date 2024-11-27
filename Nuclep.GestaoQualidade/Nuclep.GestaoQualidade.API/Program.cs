using Nuclep.GestaoQualidade.SqlServer.Extensions;
using Nuclep.GestaoQualidade.Domain.Extensions;
using Nuclep.GestaoQualidade.Application.Extensions;
using Nuclep.GestaoQualidade.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(x => { x.LowercaseUrls = true; });
builder.Services.AddSwaggerConfig();
builder.Services.AddEntityFramework(builder.Configuration);
builder.Services.AddDomainServices();
builder.Services.AddApplicationServices();
builder.Services.AddCorsConfig(builder.Configuration);

// Registro IHttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSwaggerConfig();
app.UseAuthorization();
app.MapControllers();
app.UseCorsConfig();

app.Run();
