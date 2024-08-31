using Microsoft.EntityFrameworkCore;

namespace WarlordStore.Models
{
    public class Weapon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    //Adding context allows you to query and save instances of entities in the database.
    public class WeaponDb : DbContext
    {
        public WeaponDb(DbContextOptions options) : base(options) { }
        public DbSet<Weapon> Weapons { get; set; } = null!;
    }
}
