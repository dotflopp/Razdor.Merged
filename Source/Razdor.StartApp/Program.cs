using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

using Razdor.DataAccess.EntityFramework;
using Razdor.DataAccess.EntityFramework.Repositories;
using Razdor.Guilds.DataAccess.Core;
using Razdor.Guilds.Routing;
using Razdor.StartApp.Constraints;
using Razdor.Voices.Routing;

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


builder.Services.AddDbContext<RazdorDataContext>(options =>
{
    options.UseSqlite("Data Source=razdor.db");
});

builder.Services.AddTransient<IUserRepository, UsersRepository>();
builder.Services.AddTransient<IChannelsRepository, ChannelsRepository>();
builder.Services.AddTransient<IGuildsRepository, GuildsRepository>();

builder.Logging.SetMinimumLevel(LogLevel.Trace);

builder.Services.AddTransient<RazdorDataContext>();


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
