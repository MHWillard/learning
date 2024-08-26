namespace WarlordStore
{
    public record Weapon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class Database
    {
        private static List<Weapon> _weapons = new List<Weapon>()
        {
            new Weapon{Id=1,Name="Longsword, 1d8 damage"},
            new Weapon{Id=2,Name="Axe, 1d10 damage, two-handed"},
            new Weapon{Id=3,Name="Spear, 1d6 damage, reach"},
        };

        public static List<Weapon> GetWeapons() { return _weapons; }

        public static Weapon ? GetWeapon(int id)
        {
            return _weapons.SingleOrDefault(weapon => weapon.Id == id);
        }

        public static Weapon AddWeapon(Weapon weapon)
        {
            _weapons.Add(weapon);
            return weapon;
        }

        public static Weapon UpdateWeapon(Weapon update)
        {
            _weapons = _weapons.Select(weapon =>
            {
                if (weapon.Id == update.Id)
                {
                    weapon.Name = update.Name;
                }
                return weapon;
            }).ToList();
            return update;
        }

        public static void RemoveWeapon(int id)
        {
            _weapons = _weapons.FindAll(weapon => weapon.Id != id).ToList();
        }
    }
}
