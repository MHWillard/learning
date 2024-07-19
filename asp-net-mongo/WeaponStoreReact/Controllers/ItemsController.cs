using Microsoft.AspNetCore.Mvc;
using WeaponStoreAPI.Models;
using WeaponStoreAPI.Services;

namespace WeaponStoreAPI.Controllers
{
    //set the controller and the main route
    [ApiController]
    [Route("/api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _itemsService;

        public ItemsController(ItemsService itemsService) =>
            _itemsService = itemsService;

        //set the various CRUD operations.
        [HttpGet]
        public async Task<List<Item>> Get() =>
            await _itemsService.GetAsync();

        
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Item>> Get(string id)
        {
            var item = await _itemsService.GetAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }
        
        /*
        
        [HttpGet("{item_id}")]
        public async Task<ActionResult<Item>> Get(string item_id)
        {
            var item = await _itemsService.GetAsync(item_id);

            if (item is null)
            {
                return NotFound();
            }

            Console.WriteLine($"Query result: {item?.ToString() ?? "null"}");
            return item;
        }
        */
        


        [HttpGet("allitems")]
        //public async Task<ActionResult<List<Item>>> GetAll()
        public async Task<ActionResult<List<Item>>> GetAll()
        {
            //var items = await _itemsService.GetAsync();

            //make list of Item
            //get all item from _itemsService.GetAsync();
            //if list is null: return notFound
            //otherwise return list
            /*
                     public async Task<List<Item>> GetAsync() =>
        await _itemsCollection.Find(_ => true).ToListAsync();  
            
             

            if (items is null)
            {
                return NotFound();
            }

            return items;*/
            return await _itemsService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Item newItem)
        {
            await _itemsService.CreateAsync(newItem);

            return CreatedAtAction(nameof(Get), new { id = newItem.Id }, newItem);
        }

        [HttpPut("{item_id:length(24)}")]
        public async Task<IActionResult> Update(string item_id, Item updatedItem)
        {
            var item = await _itemsService.GetAsync(item_id);

            if (item is null)
            {
                return NotFound();
            }

            updatedItem.Id = item.Id;

            await _itemsService.UpdateAsync(item_id, updatedItem);

            return NoContent();
        }

        [HttpDelete("{item_id:length(24)}")]
        public async Task<IActionResult> Delete(string item_id)
        {
            var item = await _itemsService.GetAsync(item_id);

            if (item is null)
            {
                return NotFound();
            }

            await _itemsService.RemoveAsync(item_id);

            return NoContent();
        }
    }
}
