namespace WeaponStoreAPI.Models
{
    public class ItemStoreDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ItemsCollectionName { get; set; } = null!;
    }
}
