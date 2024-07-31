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

    public ICollection<Employees> GetAllEmployess()
    {
        return _context.Employees.OrderBy(p=>p.EmployeeFirstName).ToList();
    }

    public Employees AddEmployee(Employees emp)
    {
        if (emp == null)
        {
            throw new ArgumentNullException(nameof(emp));
        }
        var existingEmployee =  _context.Employees
            .Find(emp.Rfid);
        if (existingEmployee != null)
        {
            _context.Entry(existingEmployee).CurrentValues.SetValues(emp);
            _context.SaveChanges();
        }
        else
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
        }

        return emp;
    }

    public async Task<Employees> UpdateEmployeeImageUrl(int rfid, string imageUrl)
    {
        var employee = await _context.Employees.FindAsync(rfid);
        if (employee == null)
        {
            return null;
        }

        employee.EmployeeImageUrl = imageUrl;
        await _context.SaveChangesAsync();
        return employee;
    }
}
