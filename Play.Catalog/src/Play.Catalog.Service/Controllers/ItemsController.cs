using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Play.Catalog.Service.Dtos;

namespace Play.Catalog.Service.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private static readonly List<ItemDto> items = new()
        {
            new ItemDto(Guid.NewGuid(), "Potion", "Restores a small amount of HP", 5, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Antidote", "Cures poison effect", 7, DateTimeOffset.UtcNow),
            new ItemDto(Guid.NewGuid(), "Bronze Sword", "Deals a small amount of damage", 20, DateTimeOffset.UtcNow)
        };

        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> Get()
        {
            //Returns static list of itemDTO
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetById(Guid id)
        {
            //Returns a specific item from the itemDTO list or a null if not found
            var item = items.Where(x => x.Id == id).SingleOrDefault();
            if(item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST /items/{id}
        [HttpPost]
        public ActionResult<ItemDto> Post(CreateItemDto createItemDto)
        {
            //Creates a new item following the existing itemDTO contract
            var item = new ItemDto(
                Guid.NewGuid(), 
                createItemDto.Name, 
                createItemDto.Description, 
                createItemDto.Price,
                DateTimeOffset.UtcNow
            );

            //Adds the created item into the itemDTO list
            items.Add(item);

            //Returns the respose to the client
            return CreatedAtAction(nameof(GetById), new{id = item.Id}, item);
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = items.Where(x => x.Id == id).SingleOrDefault();
            if(existingItem == null){
                return NotFound();
            }

            //Creates a clone of the existing item
            var updatedItem = existingItem with{
                Name = updateItemDto.Name,
                Description = updateItemDto.Description,
                Price = updateItemDto.Price
            };

            //Locates the item and update it
            var itemIndex = items.FindIndex(item => item.Id == id);
            items[itemIndex] = updatedItem;

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //Locates the item and remove it from the list
            var itemIndex = items.FindIndex(item => item.Id == id);
            if (itemIndex < 0){
                return NotFound();               
            }

            items.RemoveAt(itemIndex);

            return NoContent();
        }
    }
}