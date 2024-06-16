using System.ComponentModel.DataAnnotations;
using GuitarStore.Helpers;
using GuitarStore.Models.Product;

namespace GuitarStore.Models;

public abstract class Customer : Account
{
    [Required] [MinimumAge(18)] public DateTime Birthdate { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
}