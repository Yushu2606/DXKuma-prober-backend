using DXKuma.Prober.Backend;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddDbContextPool<DatabaseContext>(opt => 
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseContext")));
WebApplication app = builder.Build();

RouteGroupBuilder api = app.MapGroup("/");
api.MapPost("/playlogs/{id:int}", (int id, HttpContext httpContext) =>
{
    throw new NotImplementedException();
});

app.Run();