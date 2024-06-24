using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuitarStore.Contexts;

namespace GuitarStore.Models.Product;

public enum RentStatus
{
    ACTIVE,
    RETURNED,
    OVERDUE,
    PENALTY_PAID
}

public class Rent
{
    // Backing fields
    private DateTime? _actualEndDate;
    private DateTime _scheduledEndDate;

    public Rent(Guid rentableItemId, Guid? trustedCustomerId, DateTime startDate,
        DateTime scheduledEndDate, AppDbContext context)
    {
        ThrowIfNotValidCustomer(trustedCustomerId, context);

        if (scheduledEndDate <= startDate)
            throw new ArgumentException("Scheduled end date must be greater than start date");

        RentableItemId = rentableItemId;
        TrustedCustomerId = trustedCustomerId;
        StartDate = startDate;
        ScheduledEndDate = scheduledEndDate;
        RentStatus = RentStatus.ACTIVE;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Required] public RentStatus RentStatus { get; set; }
    [Required] public DateTime StartDate { get; init; }

    [Required]
    public DateTime ScheduledEndDate
    {
        get => _scheduledEndDate;
        set
        {
            if (RentStatus != RentStatus.ACTIVE)
                throw new InvalidOperationException("Cannot change scheduled end date of overdue rent");

            if (value <= StartDate)
                throw new ArgumentException("Scheduled end date must be greater than start date");

            if (value < _scheduledEndDate)
                throw new ArgumentException("Scheduled end date cannot be decreased for active rents");

            _scheduledEndDate = value;
        }
    }

    public DateTime? ActualEndDate
    {
        get => _actualEndDate;
        set
        {
            if (value != null && RentStatus != RentStatus.ACTIVE)
                throw new InvalidOperationException("Cannot change actual end date of non-active rent");

            if (value != null && value < StartDate)
                throw new ArgumentException("Actual end date must be greater than start date");

            if (value != null && RentStatus == RentStatus.ACTIVE)
                RentStatus = RentStatus.RETURNED;

            _actualEndDate = value;
        }
    }

    // Relational members
    [Required] public Guid RentableItemId { get; set; }
    public Guid? TrustedCustomerId { get; set; }
    [ForeignKey("RentableItemId")] public virtual RentableItem RentableItem { get; set; }
    [ForeignKey("TrustedCustomerId")] public virtual TrustedCustomer TrustedCustomer { get; set; }


    // Methods
    private static void ThrowIfNotValidCustomer(Guid? trustedCustomerId, AppDbContext context)
    {
        if (context.Accounts.Find(trustedCustomerId) is not TrustedCustomer trustedCustomer) return;

        if (trustedCustomer.StatusExpiryDate <= DateTime.Now)
            throw new ArgumentException("Trusted customer status has expired");

        var currentRentsLength = trustedCustomer.GetActiveRents().Count + trustedCustomer.GetOverdueRents().Count;

        if (currentRentsLength >= TrustedCustomer.MaxActiveRent)
            throw new ArgumentException("Trusted customer has reached maximum active rent limit");
    }

    public float GetPenaltyAmount()
    {
        var dailyPenalty = RentableItem.RentableProduct.DailyLatePenalty;

        if (RentStatus == RentStatus.OVERDUE)
            return (float)(DateTime.Now - ScheduledEndDate).TotalDays * dailyPenalty;

        if (RentStatus == RentStatus.PENALTY_PAID && ActualEndDate != null)
            return (float)((DateTime)ActualEndDate - ScheduledEndDate).TotalDays * dailyPenalty;

        return 0;
    }
}