using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models;

public class ClassAttributes
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Range(1, 100)] public int MaxCommissionRate { get; set; } = 10; // in percents
    [Range(1, 60)] public int MaxRentDays { get; set; } = 30;
    [Range(1, 10)] public int MaxActiveRents { get; set; } = 5;
    [Range(100, 5000)] public float DepositAmount { get; set; } = 1000F;
}