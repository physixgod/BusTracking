using BusTracking.Application.Interfaces;
using BusTracking.Domain.ENTITIES;
using BusTracking.Infrastructure.DATA;

namespace BusTracking.Application.Repositories;

public class EmployeeRepository:IEmployeesRepository
{
    private readonly DataContext _context;
    public EmployeeRepository(DataContext context)
    {
        this._context = context;
    }

    public ICollection<Employees> getEmployees()
    {
        return _context.Employees.OrderBy(p=>p.EmployeeFirstName).ToList();
    }
}