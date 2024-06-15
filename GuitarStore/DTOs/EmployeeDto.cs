using GuitarStore.Helpers;
using GuitarStore.Models;

namespace GuitarStore.DTOs;

public class EmployeeDto : AccountDto
{
    public EmployeeDto()
    {
    }

    public EmployeeDto(Employee employee) : base(employee)
    {
        CommissionRate = employee.CommissionRate;
        ContractNumber = employee.ContractNumber;
        PhoneNumber = employee.PhoneNumber;
        Positions = employee.Positions;
        PrivilegeLevel = employee.PrivilegeLevel;
    }

    private int CommissionRate { get; set; }
    private string ContractNumber { get; set; }
    private string PhoneNumber { get; set; }
    private EmployeePositionEnum Positions { get; set; }
    private PrivilegeLevel PrivilegeLevel { get; set; }
}