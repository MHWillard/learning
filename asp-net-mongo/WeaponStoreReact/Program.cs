
using WeaponStoreAPI.Models;
using WeaponStoreAPI.Services;
using MongoDB.Driver;
using MongoDB.Bson;

namespace WeaponStoreAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //add CORS for testing.
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:7053/",
                                                          "http://localhost:3000");
                                  });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //add the database services to the builder, get the config and add that too.
            builder.Services.Configure<ItemStoreDatabaseSettings>(
                builder.Configuration.GetSection("ItemStoreDatabase"));

            builder.Services.AddSingleton<ItemsService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            var testClient = new MongoClient("mongodb+srv://mhwillard:9IsvJkAKxKnGJW1k@cluster0.k1mwy5p.mongodb.net/");

            List<string> databases = testClient.ListDatabaseNames().ToList();

            foreach (string database in databases)
            {
                Console.WriteLine("database: " + database);
            }
        }
    }
}
