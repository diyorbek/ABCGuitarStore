using System.ComponentModel.DataAnnotations;

namespace GuitarStore.Models.Product;

public enum CategoryEnum
{
    GUITAR,
    ACCESSORY
}

public enum GuitarEnum
{
    ELECTRIC,
    ACOUSTIC,
    BASS,
    OTHER
}

public abstract class Product
{
    private readonly GuitarEnum? _guitarType;
    private readonly List<GuitarEnum>? _usedWith;

    public Product(CategoryEnum category, string name, string description, List<string> images,
        GuitarEnum? guitarType, List<GuitarEnum>? usedWith)
    {
        if (category == CategoryEnum.GUITAR)
        {
            if (guitarType == null)
                throw new ArgumentException("Guitar type cannot be null for guitars.", nameof(guitarType));
            if (usedWith != null)
                throw new ArgumentException("Used with cannot be empty for guitars.", nameof(usedWith));
        }

        if (category == CategoryEnum.ACCESSORY)
        {
            if (guitarType != null)
                throw new ArgumentException("Guitar type must be null for accessories.", nameof(guitarType));
            if (usedWith == null)
                throw new ArgumentException("Used with cannot be null for accessories.", nameof(usedWith));
            if (usedWith.Count == 0)
                throw new ArgumentException("Used with cannot be empty for accessories.", nameof(usedWith));
        }

        Category = category;
        Name = name;
        Description = description;
        Images = images;
        GuitarType = guitarType;
        UsedWith = usedWith;
    }

    // Used for seeding
    public Product()
    {
        Id = Guid.NewGuid();
        Category = CategoryEnum.GUITAR;
        Name = "";
        Description = "";
        GuitarType = GuitarEnum.OTHER;
    }


    [Key] public Guid Id { get; init; } = Guid.NewGuid();

    [Required] public CategoryEnum Category { get; init; }

    [Required] [Length(1, 255)] public string Name { get; init; }

    [Required] [Length(1, 1000)] public string Description { get; init; }

    [Required] [Length(1, 10)] public List<string> Images { get; init; }

    public GuitarEnum? GuitarType
    {
        get
        {
            if (Category == CategoryEnum.ACCESSORY)
                return null;
            // throw new ArgumentException("Guitar type cannot exist for accessories.", nameof(GuitarType));
            return _guitarType;
        }
        init
        {
            if (Category == CategoryEnum.ACCESSORY)
                throw new ArgumentException("Guitar type cannot be set for accessories.", nameof(GuitarType));
            _guitarType = value;
        }
    }

    public List<GuitarEnum>? UsedWith
    {
        get
        {
            if (Category == CategoryEnum.GUITAR)
                return null;
            // throw new ArgumentException("Used_with cannot exist for guitars.", nameof(UsedWith));
            return _usedWith;
        }
        init
        {
            if (Category == CategoryEnum.GUITAR)
                throw new ArgumentException("Used_with cannot be set for guitars.", nameof(UsedWith));
            if (value != null) _usedWith = value;
        }
    }

    public virtual ICollection<ProductManufacturer> ProductManufacturers { get; set; }
    public virtual ICollection<ProductStore> ProductStores { get; set; }

    public List<Store> findAvailableStores()
    {
        return ProductStores.SkipWhile(ps => ps.Quantity == 0).Select(ps => ps.Store).ToList();
    }
}