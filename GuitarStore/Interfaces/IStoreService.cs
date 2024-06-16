using GuitarStore.DTOs;
using GuitarStore.Models.Product;

namespace GuitarStore.Interfaces;

public interface IStoreService
{
    Task<List<Store>> GetStoresAsync(StoreFilterDto filter);
    Task<Store?> GetStoreAsync(Guid storeId);
    Task<List<SellableProduct>> GetStoreSellableProductsAsync(Guid storeId, ProductFiltersDto filters);
    Task<SellableProduct?> GetSellableProductAsync(Guid productId);
}