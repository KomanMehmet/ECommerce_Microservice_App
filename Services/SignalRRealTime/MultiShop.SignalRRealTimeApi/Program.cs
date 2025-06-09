using MultiShop.SignalRRealTimeApi.Hubs;
using MultiShop.SignalRRealTimeApi.Services.CommentServices;
using MultiShop.SignalRRealTimeApi.Services.MessageServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Yeni eklenenler
// Register the SignalR service
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
               .AllowAnyMethod()
               .SetIsOriginAllowed((host) => true)
               .AllowCredentials();
    });
});

builder.Services.AddHttpClient(); // HttpClient servisini ekle

builder.Services.AddScoped<ISignalRMessageService, SignalRMessageService>(); // SignalRMessageService'i ekle
builder.Services.AddScoped<ISignalRCommentService, SignalRCommentService>(); // SignalRMessageService'i ekle

builder.Services.AddSignalR(); // SignalR servisini ekle
//yeni eklenenler


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

app.UseCors("CorsPolicy"); //Yeni eklenenler: CORS politikasýný uygulamak için

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<MultiShopHub>("/MultiShopHub"); // Yeni eklenenler: SignalR hub'ýný haritalamak için

app.Run();
