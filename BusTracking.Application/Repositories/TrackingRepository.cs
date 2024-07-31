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
                RFID=te.Employees.Rfid, 
                EmployeePhotoUrl=te.Employees.EmployeeImageUrl,
                EmployeeFirstName = te.Employees.EmployeeFirstName,
                EmployeeLastName = te.Employees.EmployeeLastName,
                Timestamp = te.Timestamp,
                Longitude = te.Longitude,
                Latitude = te.Latitude
            })
            .ToList();

        return todayEvents;
    }
}