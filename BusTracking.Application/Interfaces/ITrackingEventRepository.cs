using BusTracking.Domain.ENTITIES;

namespace BusTracking.Application.Interfaces;

public interface ITrackingEventRepository
{
    ICollection<TrackingEvent> GetAllTodayEvents();
    Task<ICollection<TrackingEvent>> GetBusEventsAsync();
    public ICollection<TrackingEventDto> GetEventsByEmployees();
    public ICollection<TrackingEventDto> GetEventsForCurrentMonth();
    ICollection<TrackingEventDto> GetEventsForCurrentMonthByEmployee(int rfid);
    




}