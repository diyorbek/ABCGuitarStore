using GuitarStore.DTOs;

namespace GuitarStore.Interfaces;

public interface IOrderService
{
    Task<CreateOrderErrorResponse?> CreateOrder(string customerEmail, Guid storeId, CreateOrderRequestDto dto);
}