using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using WarlordStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

//Add the context to the database in order to use the in-memory database.
builder.Services.AddDbContext<WeaponDb>(options => options.UseInMemoryDatabase("items"));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WarlordStore API",Description="Offering vital tools for all of your conquest needs.",Version="v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json","WarlordStore API V1");
    });
}

app.MapGet("/", () => "Hello World!");

// Minimal API routes that access the Database class and uses the methods in there.

//async operation: get the WeaponDb then away for it to return a list of weapons.
app.MapGet("/weapons", async (WeaponDb db) => await db.Weapons.ToListAsync());

app.Run();
