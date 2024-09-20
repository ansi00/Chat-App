var builder = WebApplication.CreateBuilder(args);

// Instantiate the Startup class and invoke its ConfigureServices method before the app is built
var startup = new API.Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);  // Configure services here

// Build the app after configuring services
var app = builder.Build();

startup.Configure(app, builder.Environment);  // Configure the HTTP pipeline here

app.Run();
