using GuitarStore.Contexts;
using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using GuitarStore.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Services;

public class StoreService(AppDbContext context) : IStoreService
{
    public async Task<List<Store>> GetStoresAsync(StoreFilterDto filter)
    {
        return await context.Stores.Where(store =>
            (string.IsNullOrEmpty(filter.Name) || store.Name.ToLower().Contains(filter.Name.ToLower())) &&
            (string.IsNullOrEmpty(filter.City) || store.Address.City.ToLower().Contains(filter.City.ToLower()))
        ).ToListAsync();
    }

    public async Task<Store?> GetStoreAsync(Guid storeId)
    {
        return await context.Stores.FindAsync(storeId);
    }


    public async Task<List<SellableProduct>?> GetStoreSellableProductsAsync(Guid storeId, ProductFiltersDto filters)
    {
        return await context.ProductStores
            .Include(s => s.Product)
            .Where(s => s.StoreId == storeId &&
                        (string.IsNullOrEmpty(filters.Name) || s.Product.Name.ToLower().Contains(filters.Name.ToLower())) &&
                        (filters.Category == null || s.Product.Category == filters.Category))
            .Select(s => (SellableProduct)s.Product)
            .ToListAsync();
    }

    public async Task<SellableProductDetailsDto?> GetSellableProductDetailsAsync(Guid productId)
    {
        return await context.Products.Include(p => p.ProductManufacturers)
            .ThenInclude(p => p.Manufacturer)
            .Where(p => p.Id == productId)
            .Select(p => new SellableProductDetailsDto((SellableProduct)p))
            .FirstOrDefaultAsync();
    }

    public async Task<SellableProductQuantityDto?> GetSellableProductQuantityAsync(Guid storeId, Guid productId)
    {
        return await context.ProductStores
            .Include(s => s.Product)
            .Where(s => s.StoreId == storeId && s.ProductId == productId)
            .Select(s => new SellableProductQuantityDto { Quantity = s.Quantity })
            .FirstOrDefaultAsync();
    }

    public async Task<List<Store>?> GetSellableProductAvailableStoresAsync(Guid productId)
    {
        var product = await context.Products
            .Include(p => p.ProductStores)
            .ThenInclude(ps => ps.Store)
            .Where(p => p.Id == productId).FirstOrDefaultAsync();

        return product?.findAvailableStores();
    }

    public async Task<CreateOrderErrorResponse?> ValidateOrderQuantity(Guid storeId, CreateOrderRequestDto dto)
    {
        foreach (var orderProductDto in dto.products)
        {
            var availableQuantityDto =
                await GetSellableProductQuantityAsync(storeId, orderProductDto.ProductId);

            if (availableQuantityDto == null)
                return new CreateOrderErrorResponse { Status = 404, Message = "Product unavailable" };
            if (availableQuantityDto.Quantity < orderProductDto.Quantity)
                return new CreateOrderErrorResponse { Status = 400, Message = "Please reduce quantity" };
            if (orderProductDto.Quantity == 0)
                return new CreateOrderErrorResponse { Status = 400, Message = "Incorrect quantity" };
        }

        return null;
    }
}