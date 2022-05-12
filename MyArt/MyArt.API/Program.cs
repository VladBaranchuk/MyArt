using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyArt.API.Helpers;
using MyArt.API.Hubs;
using MyArt.API.Infrastructure.Configurations;
using MyArt.BusinessLogic.Contracts;
using MyArt.BusinessLogic.Models;
using MyArt.BusinessLogic.Services;
using MyArt.DataAccess;
using MyArt.DataAccess.Contracts;
using System.Collections;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



var jwtConfig = new JwtOptions();

// Add services to the container.

builder.Host.ConfigureAppConfiguration(config =>
{
    var prefix = "API_";
    config.AddEnvironmentVariables(prefix);
});

Console.WriteLine(new String('=', 10));
foreach (var key in Environment.GetEnvironmentVariables())
{
    var f = (DictionaryEntry)key;
    Console.WriteLine("{0} = {1}", f.Key, f.Value);
}

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IDataContext, DataContext>();

builder.Configuration.GetSection("JwtOptions").Bind(jwtConfig);
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddSignalR();
builder.Services.AddSingleton<IUserIdProvider, NameUserIdProvider>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidateAudience = true,
        ValidAudience = jwtConfig.Audience,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.SecretKey))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/Notification")))
            {
                context.Token = accessToken;
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddDataAccess();
builder.Services.AddMappings();
builder.Services.AddValidators();

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<IArtService, ArtService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IBoardService, BoardService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.AllowAnyHeader()
                          .AllowAnyMethod()
                          .SetIsOriginAllowed(origin => true)
                          .AllowCredentials());
});


var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(x => {
    x.MapDefaultControllerRoute();
    x.MapHub<NotificationHub>("/Notification");
});

app.Run();
