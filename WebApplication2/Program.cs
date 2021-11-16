using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("configuration.json");
builder.Services.AddOcelot(builder.Configuration);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

//app.Run();
await app.UseOcelot();

//app.UseHttpsRedirection();

app.UseRouting();

//app.UseAuthorization();
// app.UseUrls();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
