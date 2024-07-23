using BusTracking.Domain.ENTITIES;

namespace BusTracking.Application.Interfaces;

public interface ITrackingEventRepository
{
    ICollection<TrackingEvent> getTodayEvents();

}