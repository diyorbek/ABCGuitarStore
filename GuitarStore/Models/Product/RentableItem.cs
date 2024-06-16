using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models.Product;

public class RentableItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] [Length(1, 255)] public string ItemCode { get; set; }

    [Required] public Guid RentableProductId { get; set; }
    [ForeignKey("RentableProductId")] public virtual RentableProduct RentableProduct { get; set; }

    public virtual ICollection<Rent> Rents { get; set; }
}