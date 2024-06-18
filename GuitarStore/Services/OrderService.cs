using GuitarStore.Contexts;
using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using GuitarStore.Models;
using GuitarStore.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Services;

public class OrderService(AppDbContext context) : IOrderService
{
    public async Task<CreateOrderErrorResponse?> CreateOrder(string customerId, Guid storeId,
        CreateOrderRequestDto dto)
    {
        var customer = (Customer?)await context.Accounts.FindAsync(new Guid(customerId));
        var store = await context.Stores.FindAsync(storeId);

        if (customer == null) return new CreateOrderErrorResponse { Status = 400, Message = "User doesn't exist" };

        var order = new Order
        {
            Customer = customer,
            OrderItems = dto.products.Select(p => new OrderItem
            {
                SellableProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList()
        };

        await context.Orders.AddAsync(order);
        var storeProducts = context.ProductStores
            .Include(ps => ps.Store)
            .Include(ps => ps.Product)
            .Where(ps => store != null && ps.StoreId == store.Id).ToList();

        foreach (var orderOrderItem in order.OrderItems)
        {
            var sellableProductAssoc =
                storeProducts.FirstOrDefault(sp => sp.ProductId == orderOrderItem.SellableProductId);

            if (sellableProductAssoc == null) continue;
            
            sellableProductAssoc.Quantity -= orderOrderItem.Quantity;
            context.ProductStores.Update(sellableProductAssoc);
        }

        await context.SaveChangesAsync();

        return null;
    }
}