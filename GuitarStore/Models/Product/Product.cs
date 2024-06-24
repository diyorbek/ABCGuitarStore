using System.ComponentModel.DataAnnotations;
using GuitarStore.Contexts;

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
    [Required] [Length(1, 255)] public string Name { get; set; }
    [Required] [Length(1, 1000)] public string Description { get; set; }
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
                // throw new ArgumentException("Used_with cannot exist for guitars.", nameof(UsedWith));
                return null;
            return _usedWith;
        }
        init
        {
            if (Category == CategoryEnum.GUITAR)
                throw new ArgumentException("Used_with cannot be set for guitars.", nameof(UsedWith));
            if (value != null) _usedWith = value;
        }
    }

    // Relational collections
    public virtual ICollection<Manufacturer> Manufacturers { get; init; }
    public virtual ICollection<ProductStore> ProductStores { get; init; }

    // Methods
    public List<Store> FindAvailableStores()
    {
        return ProductStores.SkipWhile(ps => ps.Quantity == 0).Select(ps => ps.Store).ToList();
    }

    public void AddImage(string image)
    {
        ArgumentNullException.ThrowIfNull(image);
        Images.Add(image);
    }

    public void RemoveImage(string image)
    {
        ArgumentNullException.ThrowIfNull(image);
        Images.Remove(image);
    }

    public void AddManufacturer(Manufacturer manufacturer)
    {
        ArgumentNullException.ThrowIfNull(manufacturer);
        Manufacturers.Add(manufacturer);
    }

    public void RemoveManufacturer(Manufacturer manufacturer)
    {
        ArgumentNullException.ThrowIfNull(manufacturer);
        Manufacturers.Remove(manufacturer);
    }

    public void AddUsedWith(GuitarEnum guitar)
    {
        if (Category == CategoryEnum.GUITAR)
            throw new ArgumentException("Used_with cannot be set for guitars.", nameof(UsedWith));

        UsedWith?.Add(guitar);
    }

    public static List<Product> FindByName(AppDbContext context, string name)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty", nameof(name));

        return context.Products.Where(p => p.Name == name).ToList();
    }

    public static List<Product> FilterByGuitarTypes(AppDbContext context, List<GuitarEnum> guitarTypes)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(guitarTypes);

        if (guitarTypes.Count == 0) throw new ArgumentException("Guitar types cannot be empty", nameof(guitarTypes));

        return context.Products.Where(p =>
                p.GuitarType != null
                    ? guitarTypes.Contains((GuitarEnum)p.GuitarType!)
                    : p.UsedWith!.Intersect(guitarTypes)
                        .Any())
            .ToList();
    }
}