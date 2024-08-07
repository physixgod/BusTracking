﻿using BusTracking.Application.Interfaces;
using BusTracking.Application.Repositories;
using BusTracking.Domain.ENTITIES;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers;
[Route("bustracking/[controller]")]
[ApiController]
public class EventsController:ControllerBase
{
    private readonly ITrackingEventRepository _trackingEvent;

    public EventsController(ITrackingEventRepository trackingRepository)
    {
        _trackingEvent = trackingRepository;
    }
    [HttpGet("getTodayEvents")]
    public IActionResult GetTodayEvents()
    {
        return Ok(_trackingEvent.GetAllTodayEvents());
    }
    [HttpGet("getTodayEventsByEmployees")]
    public IActionResult GetTodayEventsByEmployees()
    {
        return Ok(_trackingEvent.GetEventsByEmployees());
    }

    [HttpGet("GetMonthlyEvents")]
    public IActionResult GetMonthlyEvents()
    {
        return Ok(_trackingEvent.GetEventsForCurrentMonth());
    }

    [HttpGet("GetMonthlyEvents/{rfid}")]
    public IActionResult GetMonthlyEvents(int rfid)
    {
        return Ok(_trackingEvent.GetEventsForCurrentMonthByEmployee(rfid));
    }


    
}