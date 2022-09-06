using JsonProjectBE.DBRepo;
using Microsoft.Extensions.Http;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using JsonProjectBE.Services;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<Mongo>();

builder.Services.AddScoped<IDBRepo,Mongo>();
//builder.Services.AddScoped<IPokemonService, PokemonService>();

builder.Services.AddHttpClient<IPokemonService, PokemonService>()
                .AddPolicyHandler(GetRetryPolicy());

IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                        retryAttempt)));
}

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
app.UseDeveloperExceptionPage();