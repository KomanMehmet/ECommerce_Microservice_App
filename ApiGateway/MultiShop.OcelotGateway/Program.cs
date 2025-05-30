using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Yeni  eklenenler
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();
//Yeni eklenenler

app.MapGet("/", () => "Hello World!");

app.Run();
