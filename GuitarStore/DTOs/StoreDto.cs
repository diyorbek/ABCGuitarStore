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
    public CategoryEnum? category { get; set; }
}