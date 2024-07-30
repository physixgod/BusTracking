using BusTracking.Application.Interfaces;
using BusTracking.Domain.ENTITIES;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers;
[Route("bustracking/[controller]")]
[ApiController] 
public class EmployeeController:ControllerBase
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeeController(IEmployeesRepository employeesRepository)
    {
        _employeesRepository = employeesRepository;
    }

    [HttpPost("AddEmployee")]
    public IActionResult AddEmployee(Employees employee)
    {
 
        _employeesRepository.AddEmployee(employee);
        return Ok(employee);
    }

    [HttpGet("GetAllEmployees")]
    public IActionResult GetAllEmployees()
    {
        return Ok(_employeesRepository.GetAllEmployess());
    }
    
}