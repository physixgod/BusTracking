using BusTracking.Application.Interfaces;
using BusTracking.Domain.Dto;
using BusTracking.Domain.ENTITIES;
using BusTracking.Infrastructure.DATA;
using Microsoft.EntityFrameworkCore;

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

    public List<Employees> addEmployeesList(List<Employees> employees)
    {
        if (employees == null || !employees.Any())
        {
            throw new ArgumentNullException(nameof(employees));
        }

        _context.Employees.AddRange(employees);
        _context.SaveChangesAsync();
        return employees;
    }

    public List<TrackingEventDto> GetTrackingEventsForLastMonth(int rfid)
    {
        throw new NotImplementedException();
    }

    public int GetEmployeeByTrackingEventIdAsync(int trackingEventId)
    {
        var trackingEvent = _context.TrackingEvent
            .Include(te => te.Employees)
            .SingleOrDefault(te => te.TrackingEventID == trackingEventId);
        
        var employee = trackingEvent.Employees;
        return employee.Rfid;
    }

    public Employees GetEmployeeByRFID(int rfid)
    {
        return _context.Employees.Find(rfid);
    }
}


