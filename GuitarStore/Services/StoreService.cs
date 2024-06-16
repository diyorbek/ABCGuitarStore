using GuitarStore.Contexts;
using GuitarStore.DTOs;
using GuitarStore.Interfaces;
using GuitarStore.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Services;

public class StoreService : IStoreService
{
    private readonly IConfiguration _configuration;
    private readonly AppDbContext _context;

    public StoreService(IConfiguration configuration, AppDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    public async Task<List<Store>> GetStoresAsync(StoreFilterDto filter)
    {
        return await _context.Stores.Where(store =>
            (string.IsNullOrEmpty(filter.Name) || store.Name == filter.Name) &&
            (string.IsNullOrEmpty(filter.City) || store.Address.City == filter.City)
        ).ToListAsync();
    }

    public async Task<Store?> GetStoreAsync(Guid storeId)
    {
        return await _context.Stores.FindAsync(storeId);
    }


    public async Task<List<SellableProduct>> GetStoreSellableProductsAsync(Guid storeId, ProductFiltersDto filters)
    {
        return await _context.ProductStores
            .Include(s => s.Product)
            .Where(s => s.StoreId == storeId &&
                        (filters.Name == null || s.Product.Name.Contains(filters.Name)) &&
                        (filters.category == null || s.Product.CategoryEnum == filters.category))
            .Select(s => (SellableProduct)s.Product)
            .ToListAsync();
    }

    public async Task<SellableProduct?> GetSellableProductAsync(Guid productId)
    {
        return await _context.Products.Include(p => p.ProductManufacturers)
            .ThenInclude(p => p.Manufacturer)
            .Where(p => p.Id == productId)
            .Select(p => (SellableProduct)p)
            .FirstOrDefaultAsync();
    }
}