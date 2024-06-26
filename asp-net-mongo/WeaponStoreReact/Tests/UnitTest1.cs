using WeaponStoreAPI.Controllers;
using WeaponStoreAPI.Services;
using WeaponStoreAPI.Models;
using Microsoft.Extensions.Options;

namespace Tests
{
    public class Tests
    {
        [OneTimeSetUp]
        public void ItemsInit()
        {
            /*ItemStoreDatabaseSettings iSettings = new ItemStoreDatabaseSettings();
            ItemsService iService = new ItemsService(IOptions<ItemStoreDatabaseSettings>itemStoreDatabaseSettings);
            ItemsController iController = new ItemsController*/
        }

        [Test]
        public void Test1()
        {
            //arrange
            ////set up any DB stuff
            //act
            ////poll for one item
            //assert
            //confirm document equals pulled item
            Assert.Pass();
        }
    }
}