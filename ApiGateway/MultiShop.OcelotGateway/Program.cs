using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Yeni Eeklenenler
//JWT ile ilgili
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];
    opt.Audience = "ResourceOcelot";
    opt.RequireHttpsMetadata = false;
});
//JWT ile ilgili
//Yeni  eklenenler
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

builder.Services.AddOcelot(configuration);

var app = builder.Build();

await app.UseOcelot();
//Yeni eklenenler

app.MapGet("/", () => "Hello World!");

app.Run();
