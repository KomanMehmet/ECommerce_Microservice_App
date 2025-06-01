using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Comment.Context;

var builder = WebApplication.CreateBuilder(args);


//Yeni eklenenler
//JWT ile ilgili
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerURL"];//appsettingsjson'a da eklemeyi unutma.
    opt.Audience = "ResourceComment";//identityserver'ýn configdeki ismi.
    opt.RequireHttpsMetadata = false;
});
//JWT ile ilgili

builder.Services.AddDbContext<CommentContext>();
//Yeni Eklenenler

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

//Yeni eklenen
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
