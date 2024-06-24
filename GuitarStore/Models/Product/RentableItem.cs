using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models.Product;

public class RentableItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Required] [Length(1, 255)] public string ItemCode { get; init; }

    // Relational members
    [Required] public Guid RentableProductId { get; init; }
    [ForeignKey("RentableProductId")] public virtual RentableProduct RentableProduct { get; init; }
    public virtual ICollection<Rent> Rents { get; init; }
}