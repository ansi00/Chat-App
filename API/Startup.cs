
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API {
public class Startup
{
    private readonly IConfiguration _config;
    public Startup(IConfiguration config)
    {
       _config = config;
    }


    // This method gets called by the runtime. Use this method to add services to the container.
   public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
    });
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddControllers(); // Add this line
}


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers(); // Map the controllers
    });
}


public record WeatherForecast(DateOnly Date, int TemperatureC, string Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
}}