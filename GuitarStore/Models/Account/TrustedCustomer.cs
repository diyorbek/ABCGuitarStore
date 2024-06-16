using System.ComponentModel.DataAnnotations;

namespace GuitarStore.Models;

public class TrustedCustomer : Customer
{
    private static float depositAmount;
    private static int maxActiveRent;
    private DateTime statusExpiryDate;

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
        get => depositAmount;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Deposit amount must be greater than or equal to 0.");
            depositAmount = value;
        }
    }

    public static int MaxActiveRent
    {
        get => maxActiveRent;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Max active rent must be greater than or equal to 0.");
            maxActiveRent = value;
        }
    }

    [Required]
    public DateTime StatusExpiryDate
    {
        get => statusExpiryDate;
        set
        {
            if (value < DateTime.Now)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Status expiry date must be greater than or equal to today.");
            statusExpiryDate = value;
        }
    }
}