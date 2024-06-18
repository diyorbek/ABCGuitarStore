using System.ComponentModel.DataAnnotations;
using GuitarStore.Models.Product;

namespace GuitarStore.DTOs;

public class StoreFilterDto
{
    public string? Name { get; set; }
    public string? City { get; set; }
}

public class ProductFiltersDto
{
    public string? Name { get; set; }
    public CategoryEnum? Category { get; set; }
}

public class ProductManufacturerDto(Manufacturer manufacturer)
{
    public Guid Id { get; set; } = manufacturer.Id;
    public string Name { get; set; } = manufacturer.Name;
    public string Description { get; set; } = manufacturer.Description;
    public string Country { get; set; } = manufacturer.Country;
}

public class SellableProductDetailsDto(SellableProduct product)
{
    public GuitarEnum? GuitarType { get; set; } = product.GuitarType;
    public List<string>? UsedWith { get; set; } = product.UsedWith?.Select(p => p.ToString()).ToList();
    public bool IsUsed { get; set; } = product.IsUsed;
    public float Price { get; set; } = product.Price;
    public Guid Id { get; set; } = product.Id;
    public string Category { get; set; } = product.Category.ToString();
    public string Name { get; set; } = product.Name;
    public string Description { get; set; } = product.Description;
    public List<string> Images { get; set; } = product.Images;

    public ICollection<ProductManufacturerDto> ProductManufacturers { get; set; } = product.ProductManufacturers
        .Select(pm => new ProductManufacturerDto(pm.Manufacturer))
        .ToList();
}

public class SellableProductQuantityDto
{
    public int Quantity { get; set; }
}

public class CreateOrderRequestDto
{
    public IList<OrderProductDto> products { get; set; }
}

public class OrderProductDto
{
    public Guid ProductId { get; set; }

    [Range(1, 5, ErrorMessage = "Incorrect quantity")]
    public int Quantity { get; set; }
}

public class CreateOrderErrorResponse
{
    public string Message { get; set; }
    public int Status { get; set; }
}