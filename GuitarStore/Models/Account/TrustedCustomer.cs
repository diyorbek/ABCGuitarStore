using System.ComponentModel.DataAnnotations;
using GuitarStore.Models.Product;

namespace GuitarStore.Models;

public class TrustedCustomer : Customer
{
    private static float _depositAmount;
    private static int _maxActiveRent;

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
        get => _depositAmount;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Deposit amount must be greater than or equal to 0.");
            _depositAmount = value;
        }
    }

    public static int MaxActiveRent
    {
        get => _maxActiveRent;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Max active rent must be greater than or equal to 0.");
            _maxActiveRent = value;
        }
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
}