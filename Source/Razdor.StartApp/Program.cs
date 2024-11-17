using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Razdor.DataAccess.Core;
using Razdor.DataAccess.EntityFramework;
using Razdor.DataAccess.EntityFramework.Repositories;
using Razdor.Routing;
using Razdor.Signaling.Internal;
using Razdor.StartApp.Constraints;
using Razdor.Voices.Routing;
using Razdor.Voices.Services.Signaling;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSignalR();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.ConstraintMap.Add(
        ULongRouteConstraint.Name,
        typeof(ULongRouteConstraint)
    );
});

builder.Services.AddCors(builder => 
{
    builder.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

//Logging
builder.Logging.SetMinimumLevel(LogLevel.Trace);

//db services
//TODO Вынести в отдельный метод
builder.Services.AddDbContext<RazdorDataContext>(options =>
{
    options.UseSqlite("Data Source=razdor.db");
});

builder.Services.AddTransient<IUserRepository, UsersRepository>();
builder.Services.AddTransient<IChannelsRepository, ChannelsRepository>();
builder.Services.AddTransient<IGuildsRepository, GuildsRepository>();

//Signaling services
builder.Services.AddSingleton<ISignalingServiceProvider, SignalingOneServiceProvider>();

builder.Services.AddSingleton<ISignalingInternalService>(
    new SignalingInternalService(
        builder.Configuration.GetValue<string>(
            "ASPNETCORE_URLS"
        ) + "/signaling"
    )
);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapSignalingHub();
app.MapRazdorApi();

app.Run();
