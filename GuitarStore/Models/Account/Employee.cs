using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuitarStore.Helpers;
using GuitarStore.Models.Product;

namespace GuitarStore.Models;

public class Employee : Account
{
    private static int maxCommissionRate;
    private int? commissionRate;
    private string contractNumber;
    private string phoneNumber;

    public Employee(string email, string name, string password, int? commissionRate, string contractNumber,
        string phoneNumber, EmployeePositionEnum positions, PrivilegeLevel? privilegeLevel, Guid storeId)
    {
        if (positions == EmployeePositionEnum.NONE)
            throw new ArgumentException("Employee must have at least one position.", nameof(positions));

        if (positions.HasFlag(EmployeePositionEnum.ADMIN) &&
            privilegeLevel == Helpers.PrivilegeLevel.None)
            throw new ArgumentException("Admin must have at least one privilege level.", nameof(privilegeLevel));

        if (positions.HasFlag(EmployeePositionEnum.ASSOCIATE) && commissionRate == null)
            throw new ArgumentException("Admin must be assigned to a store.", nameof(storeId));

        Email = email;
        Name = name;
        Password = password;
        CommissionRate = commissionRate;
        ContractNumber = contractNumber;
        PhoneNumber = phoneNumber;
        Positions = positions;
        PrivilegeLevel = privilegeLevel;
        StoreId = storeId;
    }

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
    
    public int? CommissionRate
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

    [Required] public EmployeePositionEnum Positions { get; set; }

    public PrivilegeLevel? PrivilegeLevel { get; set; }

    public Guid StoreId { get; set; }
    [ForeignKey("StoreId")] public virtual Store Store { get; set; }
}