using System.ComponentModel.DataAnnotations;
using GuitarStore.Helpers;

namespace GuitarStore.Models;

public abstract class Customer : Account
{
    [Required] [MinimumAge(18)] public DateTime Birthdate { get; set; }
}