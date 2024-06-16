using System.ComponentModel.DataAnnotations;
using GuitarStore.Helpers;
using GuitarStore.Models;

namespace GuitarStore.DTOs;

public class CustomerDto : AccountDto
{
    public CustomerDto()
    {
    }

    public CustomerDto(Customer customer) : base(customer)
    {
        Birthdate = customer.Birthdate;

        if (customer is TrustedCustomer trustedCustomer)
            StatusExpiryDate = trustedCustomer.StatusExpiryDate;
    }

    [Required] [MinimumAge(18)] public DateTime Birthdate { get; set; }

    public DateTime StatusExpiryDate { get; set; }
}