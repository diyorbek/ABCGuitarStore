using GuitarStore.Contexts;
using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using GuitarStore.Models;
using GuitarStore.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Services;

public class OrderService(AppDbContext context, StoreService storeService) : IOrderService
{
    public async Task<CreateOrderErrorResponse?> CreateOrder(string customerEmail, Guid storeId,
        CreateOrderRequestDto dto)
    {
        var validation = await ValidateOrderQuantity(storeId, dto);
        if (validation != null) return validation;

        var customer = await context.Accounts
            .Where(c => c.Email == customerEmail)
            .Select(c => (Customer)c)
            .FirstOrDefaultAsync();

        if (customer == null) return new CreateOrderErrorResponse { Status = 400, Message = "User doesn't exist" };

        context.Orders.Add(new Order
        {
            Customer = customer,
            OrderItems = dto.products.Select(p => new OrderItem
            {
                SellableProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList()
        });

        return null;
    }

    private async Task<CreateOrderErrorResponse?> ValidateOrderQuantity(Guid storeId, CreateOrderRequestDto dto)
    {
        foreach (var orderProductDto in dto.products)
        {
            var availableQuantityDto =
                await storeService.GetSellableProductQuantityAsync(storeId, orderProductDto.ProductId);

            if (availableQuantityDto == null || availableQuantityDto.Quantity < orderProductDto.Quantity)
                return new CreateOrderErrorResponse { Status = 400, Message = "Please reduce quantity" };
        }

        return null;
    }
}