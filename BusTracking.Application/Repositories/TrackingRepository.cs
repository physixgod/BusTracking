using BusTracking.Application.Interfaces;
using BusTracking.Domain.ENTITIES;
using BusTracking.Infrastructure.DATA;

namespace BusTracking.Application.Repositories;

public class TrackingRepository:ITrackingEventRepository
{
    private readonly DataContext _context;
    public TrackingRepository(DataContext context)
    {
        this._context = context;
    }
    public ICollection<TrackingEvent> getTodayEvents()
    {
        var today = DateTime.UtcNow.Date; 
        var endOfDay = today.AddDays(1); 
        var todayEvents = _context.TrackingEvent
            .Where(te => te.Timestamp >= today && te.Timestamp < endOfDay)
            .ToList();
        
        return todayEvents;
    }
}