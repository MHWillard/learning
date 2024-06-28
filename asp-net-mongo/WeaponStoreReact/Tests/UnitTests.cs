using WeaponStoreAPI.Controllers;
using WeaponStoreAPI.Services;
using WeaponStoreAPI.Models;
using Microsoft.Extensions.Options;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void ShouldReturnItem()
        {
            ItemsService _itemsService = new ItemsService();
            ItemsController itemsController = new ItemsController(_itemsService);

            var item = itemsController.Get("666c5468aee4002868a26a13");


        }
    }
}