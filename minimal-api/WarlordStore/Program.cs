using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using WarlordStore.Models;

var builder = WebApplication.CreateBuilder(args);
//check configuration and get the Weapons config string, or use the one in quotes if not present
var connectionString = builder.Configuration.GetConnectionString("Weapons") ?? "Data Source=Weapons.db";

builder.Services.AddEndpointsApiExplorer();

//Add the context to the database in order to use the in-memory database.
//builder.Services.AddDbContext<WeaponDb>(options => options.UseInMemoryDatabase("items"));

//This version adds the SQLite persistent database using the string generated above.
builder.Services.AddSqlite<WeaponDb>(connectionString);

//We also need to run: dotef migrations add InitialCreate to set up the migration
//then: dotnet ef database update to make the database and schema

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

//// Minimal API routes that access the Database class and uses the methods in there.

//async operation: get the WeaponDb then away for it to return a list of weapons.
app.MapGet("/weapons", async (WeaponDb db) => await db.Weapons.ToListAsync());

//get one weapon by id
app.MapGet("/weapon/{id}", async (WeaponDb db, int id) => await db.Weapons.FindAsync(id));

//async: add a weapon
app.MapPost("/weapon", async (WeaponDb db, Weapon weapon) =>
{
    await db.Weapons.AddAsync(weapon);
    await db.SaveChangesAsync();
    return Results.Created($"/weapon/{weapon.Id}", weapon);
});

//update existing item: when successful, still needs to return something, so return no content
app.MapPut("/weapon/{id}", async(WeaponDb db, Weapon updateweapon, int id) => 
{
    var weapon = await db.Weapons.FindAsync(id);
    if (weapon is null) return Results.NotFound();
    weapon.Name = updateweapon.Name;
    weapon.Description = updateweapon.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

//delete a weapon
app.MapDelete("/weapon/{id}", async (WeaponDb db, int id) =>
{
    var weapon = await db.Weapons.FindAsync(id);
    if (weapon is null)
    {
        return Results.NotFound();
    }
    db.Weapons.Remove(weapon);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.Run();
