using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using McDonaldsAPI.Model;
using System.Collections.Specialized;
using McDonaldsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<McDatabaseContext>();
builder.Services.AddTransient<IOrderRepository, FakeOrderRepository>();

// builder.Services.AddTransient
    /* Vive apenas no tempo que a requisição ficar ativa. */
// builder.Services.AddScoped
    /* Vive apenas no tempo que a requisição ficar ativa. Contudo, pode ser reutilizado */
// builder.Services.AddSingleton
    /* A partir do momento que ele é invocado, ele sempre permanecerá ativo */
    
/*     
            ^
   Scoped   |                                       _______________
            |                                       .             .
  Transient |                                       _______________
            |                                       .             .
  Singleton |           ____________________________._____________._______________________
            |           .                           .             .
    req3    |           .                           _______________
            |           .
    req2    |           .       _____________
            |           .
    req1    |           __________
            |
    Server  | ____________________________________________________________________________ 
            |______________________________________________________________________________>

            S———————————————————————                            T————————.———————————————
               .     .                                          T——.—————.———————————————
               .     .                                             .     .
            T——.—————.———————————————                           T——.—————.———————————————
            T——.—————.———————————————                           T——.—————.———————————————
 */
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
