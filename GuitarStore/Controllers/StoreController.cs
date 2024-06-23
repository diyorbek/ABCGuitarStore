using System.Security.Claims;
using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GuitarStore.Controllers;

[Route("api/store")]
[ApiController]
public class StoreController(IStoreService storeService, IOrderService orderService) : ControllerBase
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
    public async Task<IActionResult> GetSellableProducts(Guid storeId, [FromQuery] ProductFiltersDto filter)
    {
        var store = await storeService.GetStoreAsync(storeId);
        if (store == null) return NotFound();

        var result = await storeService.GetStoreSellableProductsAsync(storeId, filter);
        return Ok(new { store, result });
    }

    [HttpGet]
    [Authorize]
    [Route("{storeId:Guid}/{productId:guid}", Name = "GetSellableProductQuantity")]
    public async Task<IActionResult> GetSellableProductQuantity(Guid storeId, Guid productId)
    {
        var result = await storeService.GetSellableProductQuantityAsync(storeId, productId);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    [Authorize]
    [Route("{storeId:Guid}/order", Name = "CreateOrder")]
    public async Task<IActionResult> CreateOrder(Guid storeId, [FromBody] CreateOrderRequestDto dto)
    {
        var customerId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value!;
        var validation = await storeService.ValidateOrderQuantity(storeId, dto);
        if (validation != null) return BadRequest(validation);

        var result = await orderService.CreateOrder(customerId, storeId, dto);
        if (result != null) return BadRequest(result);

        return Created();
    }
}