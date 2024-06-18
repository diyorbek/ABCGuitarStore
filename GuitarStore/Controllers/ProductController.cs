using GuitarStore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController(IStoreService storeService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    [Route("{productId:guid}", Name = "GetSellableProduct")]
    public async Task<IActionResult> GetSellableProduct(Guid productId)
    {
        var result = await storeService.GetSellableProductDetailsAsync(productId);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    [Route("{productId:guid}/available-stores", Name = "GetAvailableStores")]
    public async Task<IActionResult> GetAvailableStores(Guid productId)
    {
        var result = await storeService.GetSellableProductAvailableStoresAsync(productId);
        if (result == null) return NotFound();
        return Ok(result);
    }
}