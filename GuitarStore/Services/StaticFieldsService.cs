using GuitarStore.Contexts;
using GuitarStore.Models;
using GuitarStore.Models.Product;

namespace GuitarStore.Services;

public class StaticFieldsService
{
    private readonly AppDbContext _context;
    public readonly ClassAttributes ClassAttributes;

    public StaticFieldsService(AppDbContext context)
    {
        _context = context;

        // Initialize with defaults if not found in the database
        ClassAttributes = _context.ClassAttributes.FirstOrDefault() ?? new ClassAttributes();
        _context.ClassAttributes.Update(ClassAttributes);
        _context.SaveChanges();

        // Manually initialize static fields of classes
        Employee.InitializeStaticMembersService(this);
        TrustedCustomer.InitializeStaticMembersService(this);
        RentableProduct.InitializeStaticMembersService(this);
    }

    // Should be called everytime static field is updated
    public void UpdateClassAttributes()
    {
        _context.ClassAttributes.Update(ClassAttributes);
    }
}