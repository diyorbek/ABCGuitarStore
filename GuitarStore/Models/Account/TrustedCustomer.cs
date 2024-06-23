using System.ComponentModel.DataAnnotations;
using GuitarStore.Models.Product;
using GuitarStore.Services;

namespace GuitarStore.Models;

public class TrustedCustomer : Customer
{
    // static member control
    private static StaticFieldsService _staticFieldsService;

    private DateTime _statusExpiryDate;

    public TrustedCustomer()
    {
    }

    public TrustedCustomer(RegularCustomer customer)
    {
        Birthdate = customer.Birthdate;
        StatusExpiryDate = DateTime.Now.AddYears(1);
    }

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

    public virtual ICollection<Rent> Rents { get; set; }

    public HashSet<Rent> GetActiveRents()
    {
        return Rents.Where(rent => rent.RentStatus == RentStatus.ACTIVE).ToHashSet();
    }

    public HashSet<Rent> GetOverdueRents()
    {
        return Rents.Where(rent => rent.RentStatus == RentStatus.OVERDUE).ToHashSet();
    }

    public static void InitializeStaticMembersService(StaticFieldsService svc)
    {
        _staticFieldsService = svc;
    }
}