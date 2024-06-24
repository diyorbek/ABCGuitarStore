using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuitarStore.Helpers;
using GuitarStore.Models.Product;
using GuitarStore.Services;

namespace GuitarStore.Models;

public class Employee : Account
{
    // static member control
    private static StaticFieldsService _staticFieldsService;

    // Backing fields
    private readonly int? _commissionRate;
    private readonly string _contractNumber;
    private string _phoneNumber;

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
        get => _staticFieldsService.ClassAttributes.MaxCommissionRate;
        set => _staticFieldsService.ClassAttributes.MaxCommissionRate = value;
    }

    public int? CommissionRate
    {
        get => _commissionRate;
        init
        {
            if (value < 0 || value > MaxCommissionRate)
                throw new ArgumentOutOfRangeException(nameof(value),
                    $"Commission rate must be between 0 and {MaxCommissionRate}.");
            _commissionRate = value;
        }
    }

    [Required]
    [Length(1, 255)]
    public string ContractNumber
    {
        get => _contractNumber;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Contract number cannot be null or empty.", nameof(value));
            _contractNumber = value;
        }
    }

    [Required]
    [Phone]
    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
            _phoneNumber = value;
        }
    }

    [Required] public EmployeePositionEnum Positions { get; set; }
    public PrivilegeLevel? PrivilegeLevel { get; set; }

    // Relational members
    public Guid StoreId { get; init; }
    [ForeignKey("StoreId")] public virtual Store Store { get; init; }

    // Methods
    public static void InitializeStaticMembersService(StaticFieldsService svc)
    {
        _staticFieldsService = svc;
    }
}