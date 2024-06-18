using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers;

[Route("api/store")]
[ApiController]
public class StoreController(IStoreService storeService) : ControllerBase
{
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetStores([FromQuery] StoreFilterDto filter)
    {
        var result = await storeService.GetStoresAsync(filter);
        return Ok(result);
    }

    [HttpGet]
    [Route("{storeId:Guid}", Name = "GetSellableProducts")]
    [AllowAnonymous]
    public async Task<IActionResult> GetStores(Guid storeId, [FromQuery] ProductFiltersDto filter)
    {
        var store = await storeService.GetStoreAsync(storeId);
        if (store == null) return NotFound();

        var result = await storeService.GetStoreSellableProductsAsync(storeId, filter);
        return Ok(new { store, result });
    }
}