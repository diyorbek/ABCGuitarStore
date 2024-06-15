namespace GuitarStore.Models;

public class RegularCustomer : Customer
{
    public RegularCustomer(TrustedCustomer customer)
    {
        Birthdate = customer.Birthdate;
    }
}