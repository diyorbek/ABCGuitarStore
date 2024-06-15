using System.ComponentModel.DataAnnotations;

namespace GuitarStore.Helpers;

public class MinimumAgeAttribute : ValidationAttribute
{
    private readonly int _minimumAge;

    public MinimumAgeAttribute(int minimumAge)
    {
        _minimumAge = minimumAge;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime birthdate)
        {
            var age = DateTime.Today.Year - birthdate.Year;
            if (birthdate.Date > DateTime.Today.AddYears(-age))
                age--;

            if (age < _minimumAge) return new ValidationResult($"Customers must be at least {_minimumAge} years old.");
        }

        return ValidationResult.Success;
    }
}