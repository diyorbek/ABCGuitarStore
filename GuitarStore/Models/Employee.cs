using System.ComponentModel.DataAnnotations;
using GuitarStore.Helpers;

namespace GuitarStore.Models;

public class Employee : Account
{
    private static int maxCommissionRate;
    private int commissionRate;
    private string contractNumber;
    private string phoneNumber;

    public static int MaxCommissionRate
    {
        get => maxCommissionRate;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Max commission rate must be greater than or equal to 0.");
            maxCommissionRate = value;
        }
    }

    [Required]
    public int CommissionRate
    {
        get => commissionRate;
        set
        {
            if (value < 0 || value > MaxCommissionRate)
                throw new ArgumentOutOfRangeException(nameof(value),
                    $"Commission rate must be between 0 and {MaxCommissionRate}.");
            commissionRate = value;
        }
    }

    [Required]
    [Length(1, 255)]
    public string ContractNumber
    {
        get => contractNumber;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Contract number cannot be null or empty.", nameof(value));
            contractNumber = value;
        }
    }


    [Required]
    [Phone]
    public string PhoneNumber
    {
        get => phoneNumber;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
            phoneNumber = value;
        }
    }
    
    public EmployeePositionEnum Positions { get; set; }

    public PrivilegeLevel PrivilegeLevel { get; set; }
}