using InventoryService.Contexts;
using InventoryService.Repositories;
using Microsoft.EntityFrameworkCore;
using InventoryService;
using InventoryService.Schemas;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<InventoryServiceContext>
            (o => o.UseSqlServer(Connection.EFConnectionString()));


builder.Services.AddScoped<CatalogSchema>();
builder.Services.AddGraphQL().AddSystemTextJson()
               .AddGraphTypes(typeof(CatalogSchema), ServiceLifetime.Scoped); ;

builder.Services.AddApiVersioning();
builder.Services.AddTransient<ICatalogRepository,CatalogRepository >(); 
builder.Services.AddTransient<IProductRepository,ProductRepository >();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryService v1"));
    
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseGraphQL<CatalogSchema>();
app.UseGraphQLPlayground(options: new PlaygroundOptions()); ;
app.MapControllers();

app.Run();

