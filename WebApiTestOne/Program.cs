using WebApiTestOne;
var builder = WebApplication.CreateBuilder(args);

// creacion de clase principal Startup
var Startup = new Startup(builder.Configuration);
Startup.ConfigureServices(builder.Services);


var app = builder.Build();

Startup.Configure(app, app.Environment);

app.Run();
