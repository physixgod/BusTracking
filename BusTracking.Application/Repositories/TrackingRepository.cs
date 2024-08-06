using BusTracking.Application.Interfaces;
using BusTracking.Domain.ENTITIES;
using BusTracking.Infrastructure.DATA;
using Microsoft.EntityFrameworkCore;

namespace BusTracking.Application.Repositories;

public class TrackingRepository:ITrackingEventRepository
{
    private readonly DataContext _context;
    public TrackingRepository(DataContext context)
    {
        this._context = context;
    }
    public ICollection<TrackingEvent> GetAllTodayEvents()
    {
        var today = DateTime.UtcNow.Date; 
        var endOfDay = today.AddDays(1); 
        var todayEvents = _context.TrackingEvent
            .Where(te => te.Timestamp >= today && te.Timestamp < endOfDay)
            .ToList();
        return todayEvents;
    }

    public async Task<ICollection<TrackingEvent>> GetBusEventsAsync()
    {
        var events = await _context.TrackingEvent
            .Where(te => te.DeviceID == 1)
            .ToListAsync();
        return events;
    }

    public ICollection<TrackingEventDto> GetEventsByEmployees()
    {
        var today = DateTime.UtcNow.Date;
        var endOfDay = today.AddDays(1);
        var todayEvents = _context.TrackingEvent
            .Include(te => te.Employees)
            .Where(te => te.Timestamp >= today && te.Timestamp < endOfDay)
            .Select(te => new TrackingEventDto
            {
                TrackingEventID = te.TrackingEventID,
                RFID=te.Employees.Rfid, 
                EmployeePhotoUrl=te.Employees.EmployeeImageUrl,
                EmployeeFirstName = te.Employees.EmployeeFirstName,
                EmployeeLastName = te.Employees.EmployeeLastName,
                Timestamp = te.Timestamp,
                Longitude = te.Longitude,
                Latitude = te.Latitude,
                PointingIn = te.PointingIn,
                PointingOut = te.PointingOut
            })
            .ToList();

        return todayEvents;
    }

    public ICollection<TrackingEventDto> GetEventsForCurrentMonth()
    {
        var firstDayOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
        var nextMonth = firstDayOfMonth.AddMonths(1);
        var eventsForMonth = _context.TrackingEvent
            .Include(te => te.Employees)
            .Where(te => te.Timestamp >= firstDayOfMonth && te.Timestamp < nextMonth)
            .Select(te => new TrackingEventDto
            {
                RFID = te.Employees.Rfid,
          
                EmployeeFirstName = te.Employees.EmployeeFirstName,
                EmployeeLastName = te.Employees.EmployeeLastName,
                Timestamp = te.Timestamp,
                Longitude = te.Longitude,
                Latitude = te.Latitude,
                PointingIn = te.PointingIn,
                PointingOut = te.PointingOut
            })
            .ToList();

        return eventsForMonth;
    }

    public ICollection<TrackingEventDto> GetEventsForCurrentMonthByEmployee(int rfid)
    {
        var today = DateTime.UtcNow.Date; 
        var startOfMonth = new DateTime(today.Year, today.Month, 1);
        var endOfMonth = startOfMonth.AddMonths(1);
        var events = _context.TrackingEvent
            .Include(te => te.Employees)
            .Where(te => te.Employees.Rfid == rfid &&
                         te.Timestamp >= startOfMonth && te.Timestamp < endOfMonth)
            .Select(te => new TrackingEventDto
            {
                RFID = te.Employees.Rfid,
                EmployeePhotoUrl = te.Employees.EmployeeImageUrl,
                EmployeeFirstName = te.Employees.EmployeeFirstName,
                EmployeeLastName = te.Employees.EmployeeLastName,
                Timestamp = te.Timestamp,
                PointingIn = te.PointingIn,
                PointingOut = te.PointingOut
            })
            .ToList();

        return events;
    }
}

