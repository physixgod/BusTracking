using BusTracking.Application.Repositories;
using BusTracking.Domain.ENTITIES;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers;
[Route("bustracking/[controller]")]
[ApiController]
public class EventsController:ControllerBase
{
    private readonly TrackingRepository _trackingEvent;

    public EventsController(TrackingRepository trackingRepository)
    {
        _trackingEvent = trackingRepository;
    }
    [HttpGet("getTodayEvents")]
    public IActionResult getTodayEvents()
    {
        return Ok(_trackingEvent.getTodayEvents());
    }
    
    
}