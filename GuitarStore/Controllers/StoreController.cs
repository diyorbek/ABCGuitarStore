using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers;

[Route("api/store")]
[ApiController]
[AllowAnonymous]
public class StoreController(IStoreService storeService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetStores([FromQuery] StoreFilterDto filter)
    {
        var result = await storeService.GetStoresAsync(filter);
        return Ok(result);
    }

    [HttpGet]
    [Route("{storeId:Guid}", Name = "GetSellableProducts")]
    public async Task<IActionResult> GetStores(Guid storeId, [FromQuery] ProductFiltersDto filter)
    {
        var store = await storeService.GetStoreAsync(storeId);
        var result = await storeService.GetStoreSellableProductsAsync(storeId, filter);
        return Ok(new { store, result });
    }
    
    [HttpGet]
    [Route("{storeId:Guid}/{productId:guid}", Name = "GetSellableProduct")]
    public async Task<IActionResult> GetProduct(Guid storeId,Guid productId)
    {
        var result = await storeService.GetSellableProductAsync(productId);
        return Ok(result);
    }
}