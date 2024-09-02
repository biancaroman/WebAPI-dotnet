
using Microsoft.OpenApi.Models;
 
var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
builder.Services.AddHttpClient();
 
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Conversão de Taxas de Câmbio",
        Version = "v1",
        Description = "Esta API fornece a taxa de câmbio atualizada do Dólar Americano (USD) para o Real Brasileiro (BRL).",
    });
 
});
 
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
});
 
var app = builder.Build();
 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.UseHttpsRedirection