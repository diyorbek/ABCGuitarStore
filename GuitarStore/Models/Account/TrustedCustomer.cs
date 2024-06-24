using System.ComponentModel.DataAnnotations;
using GuitarStore.Models.Product;
using GuitarStore.Services;

namespace GuitarStore.Models;

public class TrustedCustomer : Customer
{
    // Static member control
    private static StaticFieldsService _staticFieldsService;

    // Backing fields
    private DateTime _statusExpiryDate;

    // Default constructor
    public TrustedCustomer()
    {
    }

    // Copy constructor for dynamic inheritance
    public TrustedCustomer(RegularCustomer customer)
    {
        Birthdate = customer.Birthdate;
        StatusExpiryDate = DateTime.Now.AddYears(1);
    }

    [Required]
    public DateTime StatusExpiryDate
    {
        get => _statusExpiryDate;
        set
        {
            if (value < DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Status expiry date must be greater than or equal to today.");
            _statusExpiryDate = value;
        }
    }

    // Relational collection
    public virtual ICollection<Rent> Rents { get; init; }

    // Static members
    public static float DepositAmount
    {
        get => _staticFieldsService.ClassAttributes.DepositAmount;
        set => _staticFieldsService.ClassAttributes.DepositAmount = value;
    }

    public static int MaxActiveRent
    {
        get => _staticFieldsService.ClassAttributes.MaxActiveRents;
        set => _staticFieldsService.ClassAttributes.MaxActiveRents = value;
    }

    // Methods
    public List<Rent> GetActiveRents()
    {
        return Rents.Where(rent => rent.RentStatus == RentStatus.ACTIVE).ToList();
    }

    public List<Rent> GetOverdueRents()
    {
        return Rents.Where(rent => rent.RentStatus == RentStatus.OVERDUE).ToList();
    }

    public static void InitializeStaticMembersService(StaticFieldsService svc)
    {
        _staticFieldsService = svc;
    }
}