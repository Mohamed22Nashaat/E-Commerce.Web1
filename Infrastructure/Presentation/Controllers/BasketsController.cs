using Microsoft.AspNetCore.Mvc;
using ServicesAbstractions;
using Shared.DataTransferObjects.Basket;

namespace Presentation.Controllers
{
    public class BasketsController(IServiceManager serviceManager)
        : APIController
    {
        // Get Basket By Id
        [HttpGet]
        public async Task<ActionResult<BasketDTO>> Get(string id)
        {
            var basket = await serviceManager.BasketService.GetAsync(id);
            return Ok(basket);
        }
        // Update Basket (basketDto) => Create Basket ,Add item to basket, remove item from basket
        [HttpPost]
        public async Task<ActionResult<BasketDTO>> Update(BasketDTO basketDto)
        {
            var basket = await serviceManager.BasketService.UpdateAsync(basketDto);
            return Ok(basket);
        }
        // Delete Basket
        [HttpDelete("{id}")]
        public async Task<ActionResult<BasketDTO>> Delete(string id)
        {
             await serviceManager.BasketService.DeleteAsync(id);
            return NoContent();  //204
        }
    }
}
