using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    public Product(CategoryEnum categoryEnum, string name, string description, HashSet<string> images,
        GuitarEnum? guitarType, HashSet<GuitarEnum>? usedWith)
    {
        if (categoryEnum == CategoryEnum.GUITAR)
        {
            if (guitarType == null)
                throw new ArgumentException("Guitar type cannot be null for guitars.", nameof(guitarType));
            if (usedWith != null)
                throw new ArgumentException("Used with cannot be empty for guitars.", nameof(usedWith));
        }

        if (categoryEnum == CategoryEnum.ACCESSORY)
        {
            if (guitarType != null)
                throw new ArgumentException("Guitar type must be null for accessories.", nameof(guitarType));
            if (usedWith == null)
                throw new ArgumentException("Used with cannot be null for accessories.", nameof(usedWith));
            if (usedWith.Count == 0)
                throw new ArgumentException("Used with cannot be empty for accessories.", nameof(usedWith));
        }

        CategoryEnum = categoryEnum;
        Name = name;
        Description = description;
        Images = images;
        GuitarType = guitarType;
        UsedWith = usedWith;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] public CategoryEnum CategoryEnum { get; set; }

    [Required] [Length(1, 255)] public string Name { get; set; }

    [Required] [Length(1, 1000)] public string Description { get; set; }

    [Required] [Length(1, 10)] public HashSet<string> Images { get; set; }

    public GuitarEnum? GuitarType { get; set; }
    public HashSet<GuitarEnum>? UsedWith { get; set; }

    public virtual ICollection<ProductManufacturer> ProductManufacturers { get; set; }
    public virtual ICollection<ProductStore> ProductStores { get; set; }
}