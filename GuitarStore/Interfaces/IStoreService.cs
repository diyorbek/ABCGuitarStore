using GuitarStore.DTOs;
using GuitarStore.Models.Product;

namespace GuitarStore.Interfaces;

public interface IStoreService
{
    Task<List<Store>> GetStoresAsync(StoreFilterDto filter);
    Task<Store?> GetStoreAsync(Guid storeId);
    Task<List<SellableProduct>?> GetStoreSellableProductsAsync(Guid storeId, ProductFiltersDto filters);
    Task<SellableProductDetailsDto?> GetSellableProductDetailsAsync(Guid productId);
    Task<SellableProductQuantityDto?> GetSellableProductQuantityAsync(Guid storeId, Guid productId);
    Task<List<Store>?> GetSellableProductAvailableStoresAsync(Guid productId);
}